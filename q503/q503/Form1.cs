/********************************************
** q503.cs
** Spell checker program.
** Joseph Silverstein, 5/3/11
*********************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace q503
{
    public partial class Form1 : Form
    {
        const string dictionaryFile = "dictionary.txt";
        FileStream fileToRead;
        StreamReader fin;
        string myEntireFile; // user input file as a string
        string[] myWordArray; // array of words in user text file
        string[] dictionaryWordArray; // array of words in dictionary file

        public Form1()
        {
            InitializeComponent();
            fileToRead = new FileStream(dictionaryFile, FileMode.Open);
            fin = new StreamReader(fileToRead);
            string dictionaryEntireFile = fin.ReadToEnd();
            dictionaryWordArray = dictionaryEntireFile.Split('\n'); // loads dictionary as an array of words in alphabetical order
        }

        // runs binary search on alphabetically sorted dictionary word array and returns whether it's in the dictionary
        bool isInDictionary(string word)
        {
            int index = Array.BinarySearch(dictionaryWordArray, word); // get index of word (returns -1 if not found)
            if (index >= 0)
                return true;
            return false;
        }

        // loads specified file and displays it with misspelled words highlighted
        void spellCheck(string fileName)
        {
            fileToRead = new FileStream(@fileName, FileMode.Open);
            fin = new StreamReader(fileToRead);
            richTextBox1.Clear(); // clears text box
            myEntireFile = ""; // initialize to empty
            char c; // temp char for reading in
            while (!fin.EndOfStream) {
                c = (char)fin.Read(); // gets next char
                if (!Char.IsPunctuation(c)) { // don't add punctuation marks
                    if (Char.IsUpper(c))
                        c = char.ToLower(c); // convert to lowercase
                    myEntireFile += c;
                }
            }
            fileToRead.Close();
            myWordArray = myEntireFile.Split(' ','\n'); // creates array of words in order
            int charCount = 0; // counts number of chars
            for (int i = 0; i < myWordArray.Length; i++)
            {
                richTextBox1.Text += myWordArray[i] + ' ';/*
                if (!isInDictionary(myWordArray[i])) { // if not in dictionary
                    richTextBox1.Select(charCount, myWordArray[i].Length); // highlight in red
                    richTextBox1.SelectionColor = Color.Red;
                    richTextBox1.DeselectAll(); 
                }*/
                //richTextBox1.Select(charCount, myWordArray[i].Length); // highlight in red
                //richTextBox1.SelectionColor = Color.Red;
                //richTextBox1.DeselectAll(); 
                charCount += myWordArray[i].Length + 1; // add 1 for space
                
                
                    richTextBox1.Select(charCount, 1);
                    richTextBox1.SelectionColor = Color.Red;
                
                //richTextBox1.Select(i, 1);
                //richTextBox1.SelectionColor = Color.Red;
                //richTextBox1.DeselectAll();
                //richTextBox1.Text += charCount.ToString();
            }/*
            richTextBox1.Select(5,10);
            richTextBox1.SelectionColor = Color.Red;
            //richTextBox1.DeselectAll();
            richTextBox1.Select(20, 30);
            richTextBox1.SelectionColor = Color.Red;*/
            //richTextBox1.DeselectAll();
        }

        // brings up open file dialog
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileName.EndsWith(".txt"))
                    spellCheck(openFileDialog1.FileName);
                else
                    MessageBox.Show("You fail at life. Try again.");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}