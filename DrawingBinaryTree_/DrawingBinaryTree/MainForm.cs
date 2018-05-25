﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingBinaryTree
{
    public partial class MainForm : Form
    {
        private BinaryTree<int> _binarytree = null;
        private List<int> _listValues = null;
        private int _level_height = 40;
        private int _level_depht = 0;
        private int _distance = 50;

        private Color colorR = Color.Red;
        private Color colorB = Color.Black;
        public MainForm()
        {
            InitializeComponent();
            _binarytree = new BinaryTree<int>();
            _binarytree.Add(201);
            _binarytree.Add(57);
            _binarytree.Add(109);
            _binarytree.Add(67);
            _binarytree.Add(86);
            _binarytree.Add(129);
            _binarytree.Add(111);
            _binarytree.Add(27);
            _binarytree.Add(194);
            Invalidate();
        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {

            _listValues = new List<int>();
            foreach (var val in _binarytree)
            {
                _listValues.Add(val);
            }
            _level_depht = 0;
            DrawItemsOfBinaryTree(e.Graphics);
        }

        private void DrawItemsOfBinaryTree(Graphics gr)
        {
            DrawBranchers(gr, _binarytree.RootItem);
            ++_level_depht;

            List<BinaryTreeItem<int>> list = new List<BinaryTreeItem<int>>();
            list.Add(_binarytree.RootItem);

            int drawnBranch = 1;
            while (drawnBranch < _listValues.Count)
            {
                foreach (var item in list)
                {
                    if (item.left != null) DrawBranchers(gr, item.left);
                    if (item.right != null) DrawBranchers(gr, item.right);
                    colorB = Color.Black;
                }
                int count = list.Count;
                for (int i = 0; i < count; i++)
                {
                    if (list[i].left != null)
                    {
                        list.Add(list[i].left);
                        drawnBranch++;
                    }
                    if (list[i].right != null)
                    {
                        list.Add(list[i].right);
                        drawnBranch++;
                    }
                }
                list.RemoveRange(0, count);
                ++_level_depht;
            }
        }

        private void DrawBranchers(Graphics gr, BinaryTreeItem<int> node)
        {
            if (node.left != null)
            {
                Pen myPen = new Pen(Color.Black, 1);
                gr.DrawLine(myPen,
                    _distance * _listValues.IndexOf(node.Value) + 20,
                    _level_depht * _level_height + 20,
                    _distance * _listValues.IndexOf(node.left.Value) + 20,
                    (_level_depht + 1) * _level_height + 20
                );
            }

            if (node.right != null)
            {
                Pen p = new Pen(Color.Black, 1);
                gr.DrawLine(p,
                    _distance * _listValues.IndexOf(node.Value) + 20,
                    _level_depht * _level_height + 20,
                    _distance * _listValues.IndexOf(node.right.Value) + 20,
                    (_level_depht + 1) * _level_height + 20
                );
            }

            gr.FillEllipse(
                new SolidBrush(colorR),
                (_distance * _listValues.IndexOf(node.Value) + 5),
                (_level_depht) * _level_height + 5,
                30, 30
            );

            gr.DrawString(
                node.Value.ToString(),
                this.Font,
                new SolidBrush(Color.White),
                (_distance * _listValues.IndexOf(node.Value) + 20F) - gr.MeasureString(node.Value.ToString(), this.Font).Width / 2F,
                (_level_depht * _level_height + 20) - (int)gr.MeasureString(node.Value.ToString(), this.Font).Height / 2
            );
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void AddItem_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(TxtItem.Text, out int item))
            {
                _binarytree.Add(item);
                Invalidate();
                TxtItem.Text = "";
                TxtItem.Focus();
            }
        }

        private void RemoveItem_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(TxtItem.Text, out int item))
            {
                _binarytree.Remove(item);
                Invalidate();
                TxtItem.Text = "";
                TxtItem.Focus();
            }
        }
    }
}
