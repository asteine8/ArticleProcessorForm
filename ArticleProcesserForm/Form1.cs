using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.Threading;
using Xceed.Words.NET; // Allows 4 handling of word files

public struct Article { // For storing articles in raw text form
    public string Header;
    public string Body;

    public List<string> HeaderWords;
    public List<string> BodyWords;

    public string Source;
    public string Date;

    public int categoryIndex;

    public Article(string head, string body) {
        Header = head;
        Body = body;

        HeaderWords = new List<string>();
        BodyWords = new List<string>();

        Source = "";
        Date = "";

        categoryIndex = -1; // Unassigned to category
    }
}

namespace ArticleProcesserForm {
    public partial class Form1 : Form {

        public string InputFilePath = "";
        public string OutputDirectoryPath = "";

        public List<Article> Articles = new List<Article>();

        public Form1() {
            InitializeComponent();
            openFileDialog1.Filter = "Word Document Files (*.docx)|*.docx|All files (*.*)|*.*";
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e) {
            
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e) {

        }

        private void RunButton_Click(object sender, EventArgs e) {
            
            
        }

        private void InputDirectorySearchButton_Click(object sender, EventArgs e) {
            // Opens a dialog to get the file location of the target file
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                // Console.WriteLine(openFileDialog1.FileName);
                InputFilePath = openFileDialog1.FileName;
                InputDirectoryTextBox.Text = InputFilePath;


                TextProcessing txt = new TextProcessing();

                //txt.GetStringsFromFile(InputFilePath);

                List<string> DocumentLines = txt.GetLinesFromFile(InputFilePath);
                //string[] lines = documentText.Split('\n');

                this.Articles = txt.GetArticlesFromLines(DocumentLines);

                this.Articles = txt.ProcessWordsFromArticleText(this.Articles);

                OutputListBox.Items.Clear(); // Clear listbox before adding stuff

                for (int i = 0; i < Articles.Count; i++) {
                    OutputListBox.Items.Add(Articles[i].Header);
                    //Console.WriteLine(Articles[i].Body);
                }
            }
        }

        private void OutputDirectorySearchButton_Click(object sender, EventArgs e) {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) {
                // Console.WriteLine(folderBrowserDialog1.SelectedPath);
                OutputDirectoryPath = folderBrowserDialog1.SelectedPath;
                OutputDirectoryTextBox.Text = OutputDirectoryPath;
            }
        }
    }
}

public class TextProcessing {

    private char[] PunctuationCharacters = { '.', '|', ',', '\n', '\r', ';', '"', '(', ')', '[', ']', '?', '/', '\\', '!', '#', '=', '-', '—', ':', '&', '_', '~'};

    public List<string> GetLinesFromFile(string filePath) {
        List<string> lines = new List<string>();

        //Stopwatch stopwatch = new Stopwatch();
        //stopwatch.Start();

        //DocX doc = DocX.Load(filePath);
        //string documentText = doc.Text;
        //Console.WriteLine(documentText);

        DocX doc = DocX.Load(filePath);
        System.Collections.ObjectModel.ReadOnlyCollection<Paragraph> paragraphs = doc.Paragraphs;

        for (int i = 0; i < paragraphs.Count; i++) {
            lines.Add(paragraphs[i].Text);

            //Console.WriteLine("Loading paragraph " + (i+1).ToString() + " of " + paragraphs.Count.ToString());
        }

        //stopwatch.Stop();
        //Console.WriteLine("Time elapsed: " + stopwatch.ElapsedMilliseconds.ToString() + "ms");

        return lines;
    }

    public List<Article> GetArticlesFromLines(List<string> lines) {
        List<Article> articles = new List<Article>();

        lines = RemoveAdjacentBlankLinesAndTrim(lines);

        string HeadString = "";
        string BodyString = "";
        int linesSinceDelimeter = 0;
        for (int i = 1; i < lines.Count-1; i++) { // Make list of articles delimiting by empty lines


            if (string.IsNullOrEmpty(lines[i])) {
                // Create new article
                articles.Add(new Article(HeadString, "|" + BodyString + "|")); // Add a new article
                HeadString = "";
                BodyString = "";
                linesSinceDelimeter = 0; // Reset counter
                continue;
            }

            if (linesSinceDelimeter == 0) { // This is a header line
                HeadString = lines[i];
            }
            else { // This is a body line
                BodyString += lines[i] + " "; // Add a space for neatness
            }
            linesSinceDelimeter++;
        }
        return articles;
    }

    // Function for converting multiple adjecent empty newlines from List<string> to prep for processing into individual articles
    private List<string> RemoveAdjacentBlankLinesAndTrim(List<string> lines) {
        List<string> newLines = new List<string>();
        for (int i = 0; i < lines.Count-1; i++) {
            // Search for the last delimeter index
            if (string.IsNullOrEmpty(lines[i].Trim()) && !string.IsNullOrEmpty(lines[i + 1].Trim())) {
                newLines.Add(lines[i].Trim());
            }
            else if (lines[i].Length != 0) {
                newLines.Add(lines[i].Trim());
            }
        }
        return newLines;
    }

    public List<Article> ProcessWordsFromArticleText(List<Article> articles) {

        for (int i = 0; i < articles.Count; i ++) { // Iterate through all articles
            Article tempArticle = articles[i];

            string dateString = GetTextBetweenStrings(tempArticle.Body, "Date:", "|");
            string sourceString = GetTextBetweenStrings(tempArticle.Body + "|", "Source:", "|");
            tempArticle.Date = dateString;
            tempArticle.Source = sourceString;


            //for (int j = 0; j < bodyWords.Count; j++) {
            //    Console.Write("\"" + bodyWords[j] + "\"");
            //}
            //Console.Write("\n");

            articles[i] = tempArticle;
        }

        return articles;
    }

    private string GetTextBetweenStrings(string text, string startDel, string endDel) {
        string tempText = text;

        // Change all case to lower as to ignore case
        text = text.ToLower();
        startDel = startDel.ToLower();
        endDel = endDel.ToLower();

        int startIndex = text.IndexOf(startDel);
        if (startIndex == -1) { // No instances found, return empty string
            return "";
        }
        int endIndex = text.IndexOf(endDel, startIndex); // start @ start index
        if (endIndex <= startIndex) { // No instances found, return empty string
            return "";
        }
        // Delimeters are found, we are go for stripping

        startIndex += startDel.Length; // Add length to start index so we don't include the start delimeter

        return tempText.Substring(startIndex, endIndex - startIndex - 1).Trim();
    }

    /* Obsolete, replaced with Regex
    private string ReplaceCharactersWithSpace(string RString, char[] Chars2Remove) {
        for (int i = 0; i < Chars2Remove.Length; i++) {
            RString = RString.Replace(Chars2Remove[i], ' ');
        }
        return RString;
    }
    
    private string RemoveAdjacentDuplicatesOfChar(string RString, char searchChar) {
        for (int i = RString.Length - 2; i >= 0; i--) {
            if (RString[i] == RString[i+1] && RString[i] == searchChar) {
                RString = RString.Remove(i + 1, 1); // Remove the character @ i + 1 and that character only
            }
        }
        return RString;
    }
    */
}
