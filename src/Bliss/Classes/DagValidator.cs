using System;
using System.Xml;
using System.Collections.Generic;

namespace Bliss;

public class DagValidator {
    static bool IsDagValid(XmlDocument doc)
    {
        if (doc == null)
            return false; // Input xml is missing

        // parse the XML to get list of nodes and dependencies
        Dictionary<string, List<string>> dependencies = new Dictionary<string, List<string>>();
        XmlNodeList? nodes = doc.SelectNodes("//Node");
        if (nodes == null)
            return false; // No nodes found

        foreach (XmlNode node in nodes)
        {
            string? nodeId = node.Attributes?["Id"]?.Value;
            if (nodeId == null)
                return false; // Each node should have an Id

            dependencies[nodeId] = new List<string>();
            XmlNodeList? dependencyNodes = node.SelectNodes("dependencies/Node");
            if (dependencyNodes == null)
                continue;
                
            foreach (XmlNode dependencyNode in dependencyNodes)
            {
                string? dependencyId = dependencyNode.Attributes?["Id"]?.Value;
                if (dependencyId == null)
                {
                    return false; // Dependency id is missing
                }
                dependencies[nodeId].Add(dependencyId);
            }
        }

        HashSet<string> visited = new HashSet<string>();
        HashSet<string> visiting = new HashSet<string>();

        foreach (string node in dependencies.Keys)
        {
            if (!visited.Contains(node))
            {
                if (!IsDagValidHelper(node, dependencies, visited, visiting))
                {
                    return false; // Cycle detected
                }
            }
        }

        return true;
    }

    static bool IsDagValidHelper(string node, Dictionary<string, List<string>> dependencies, HashSet<string> visited, HashSet<string> visiting)
    {
        visiting.Add(node);

        foreach (string neighbor in dependencies[node])
        {
            if (visiting.Contains(neighbor))
            {
                return false; // Cycle detected
            }

            if (!visited.Contains(neighbor))
            {
                if (!IsDagValidHelper(neighbor, dependencies, visited, visiting))
                {
                    return false;
                }
            }
        }

        visiting.Remove(node);
        visited.Add(node);

        return true;
    }
}