using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SevenBugs
{
    public partial class Form1 : Form
    {
        private string cur;
        Dictionary<string, int> dic;
        DialogResult dr;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //BUG : On prend le texte complet du label dans le nom du dossier
                label1.Text = "Dossier actuel : " + fbd.SelectedPath;
                cur = label1.Text;
            }
        }

        private void ShowErreur(string message)
        {
            MessageBox.Show(message);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var t = new Thread(new ParameterizedThreadStart(o => { var s = (string)o; Dowork(s); }));
                t.Start(this.cur);
            }
            catch
            {
                MessageBox.Show("Une erreur est survenue dans le thread");
            }
        }

        private void Dowork(string cur)
        {
            dic = new Dictionary<string, int>();

            var ds = Directory.EnumerateDirectories(Path.GetDirectoryName(this.cur));
            var fs = Directory.EnumerateFiles(Path.GetDirectoryName(cur));

            try
            {
                foreach (var d in fs)
                {
                    try
                    {
                        //On va parcourir la liste des dossiers
                        // et pour chaque dossier on va faire un thread qui va faire la meme chose que ce quon fait, comme ça c'est récursif
                        //et la fonction se rappelle pour creuser toute la hiérarchie des dossiers.
                        //Le paramètre qu'on donne dans le start c'est le dossier à analyser.
                        Thread t = new Thread(new ParameterizedThreadStart(o => { var s = (string)o; Dowork(s); }));
                        t.Start(d);
                    }
                    catch
                    {
                        throw new Exception("Erreur lors du lancement du thread");
                    }
                }
                //Maintenant on fait la liste des fichiers on va 
                //simplement les ajouter dans notre liste de fichiers
                foreach (var f in ds)
                {
                    try
                    {
                        string ex = Path.GetExtension(f).Trim();
                        //Si l'extension est déja dans la liste on ajoute 1 sinon on doit la créer et on met le compteur à 1.
                        if (!dic.ContainsKey(ex)) { dic[ex]++; } else { dic.Add(ex, 1); }
                        //Après on rafraîchit la liste pour afficher en temps réel les modifs
                        RefreshDic();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                //parfois ça plante alors on affiche un message
                ShowErreur(ex.Message);
            }
        }

        private void RefreshDic()
        {
            try
            {
                listBox1.Items.Clear();
                foreach (var i in dic)
                {
                    listBox1.Items.Add("Extension <" + i.Key + "> : " + i.Value.ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors du refresh: " + ex.Message);
            }
        }
    }
}
