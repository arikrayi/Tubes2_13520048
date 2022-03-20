﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.GraphViewerGdi;

namespace WinFormsApp1
{
    public class BFS
    {
        private string startdir;
        private string filename;
        private List<dirTree> tree;
        private Graph graph;

        public BFS(string startdir, string filename)
        {
            this.startdir = @startdir;
            this.filename = filename;
            tree = new List<dirTree>();
            graph = new Graph();
        }
        public List<dirTree> getTree()
        {
            return this.tree;
        }
        public Graph getGraph()
        {
            return this.graph;
        }
        public void bfs_search(int set)
        {
            var options = new EnumerationOptions()
            {
                IgnoreInaccessible = true, AttributesToSkip = FileAttributes.System
            };
            int i = 0;
            bool found = false;
            tree.Add(new dirTree(-999, Path.GetFileName(startdir), startdir,"Folder","Not"));
            string parentdir = startdir;
            while (i < tree.Count())
            {
                List<string> temptree = Directory.GetFiles(tree[i].directory,"*",options).ToList();
                foreach (string a in temptree)
                {
                    if ((Path.GetFileName(a) == this.filename))
                    {
                        tree.Add(new dirTree(i, Path.GetFileName(a), a, "File", "Found"));
                        found = true;
                    }
                    else
                    {
                        tree.Add(new dirTree(i, Path.GetFileName(a), a, "File", "Not"));
                    }
                    graph.AddEdge(tree[i].name, Path.GetFileName(a));
                }
                if (set == 0 && found)
                {
                    return;
                }
                temptree = Directory.GetDirectories(tree[i].directory,"*",options).ToList(); ;
                foreach (string a in temptree)
                {
                    tree.Add(new dirTree(i, Path.GetFileName(a), a, "Folder", "Not"));
                    graph.AddEdge(tree[i].name, Path.GetFileName(a));
                }
                try
                {
                    i++;
                    parentdir = tree[i].directory;
                    while (tree[i].type == "File" && i < tree.Count())
                    {
                        i++;
                        parentdir = tree[i].directory;
                    }
                }
                catch { break; }
            }
        }
    }
}
