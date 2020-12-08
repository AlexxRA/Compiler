using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LexicalAnalyzer.Analyzers;
using LexicalAnalyzer.Entities;
using LexicalAnalyzer.Entities.Tree;

namespace LexicalAnalyzer
{
    public partial class Form1 : Form
    {
        private List<Token> tokens;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("----------------------------");
            dataGridView1.Rows.Clear();
            tokens = new List<Token>();
            Lexical lexical = new Lexical();
            tokens = lexical.getTokens(textBox1.Text + "$");
            foreach(Token token in tokens)
            {
                dataGridView1.Rows.Add(token.Name, token.Type, token.TokenId);
            }
            

            Syntax syntax = new Syntax(tokens);
            var syntaxResult = syntax.Analize();
            label1.Text = syntaxResult;
            if(syntaxResult.Equals("RESULTADO CORRECTO"))
            {
                var validaSemantica = syntax.stack[1].ValidaSemantica(new List<TablaSimbolos> { });
            }
            else
            {
                Console.WriteLine("Hay un error sintactico");
            }


            

            tokens.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //textBox1.Text = "int main (){\nint a, v;\nif (a == 1)\n{\nv = 2;\n}\nreturn 0;\n}";
            //textBox1.Text = "int fact(int x, int y, int z){if(x==1){}}";
            textBox1.Text = "int fact(int a){int x, y;if (a == 1){return 1;}else{x = a - 1;y = fact(x,1,2) * a;return y;}}int main(){int a;a = fact(3);return a;}";
        }
    }
}
