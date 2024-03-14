/**************************************************************************
 *                                                                        *
 *  File:        Produs.cs                                                *
 *  Copyright:   (c) 2022, Alexandra-Catalina Poleac                      *
 *  Description: Aplicatie pentru administrare magazin de cosmetice       *
 *                                                                        *
 *                                                                        *
 **************************************************************************/


using System;
using System.Collections.Generic;
using System.IO;
using Management;

namespace Produse
{
    public class Produs: IManagement
    {
        /// <summary>
        /// Clasa care se ocupa de administrarea produselor din magazinul de cosmetice
        /// </summary>
        private List<string> _produse;
        private const string FolderProduse = "Produse\\";

        /// <summary>
        /// Constructorul clasei Produs care are rolul de a actualiza lista cu produse din fisier 
        /// </summary>
        public Produs()
        {
            try
            {
                _produse = new List<string>();
                StreamReader sr = new StreamReader(FolderProduse + "produse.txt");
                string line;
                while ((line = sr.ReadLine()) != null)
                {

                    _produse.Add(line);
                }
                sr.Close();

            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }

        /// <summary>
        /// Metoda care returneaza numarul de produse din lista  
        /// </summary>
        /// <returns>Numarul produselor din lista</returns>
        public int ListCount()
        {
            return _produse.Count;
        }

        /// <summary>
        /// Metoda care returneaza lista cu numele produselor din magazinul de cosmetice
        /// </summary>
        /// <returns>Lista cu numele produselor din magazinul de cosmetice</returns>
        public string[] ListAll()
        {
            string[] list = new string[_produse.Count];
            if (_produse.Count == 0)
            {
                return null;
            }
            for (int i = 0; i < _produse.Count; ++i)
            {
                list[i] = _produse[i];

            }
            return list;
        }

        /// <summary>
        /// Metoda care actualizeaza lista cu produse din magazinul de cosmetice
        /// </summary>
        /// <param name="nameProdus"></param>
        public void AddProdus(string nameProdus)
        {
            foreach (String st in _produse)
            {
                if (st.Equals(nameProdus))
                {
                    return;
                }
            }
            _produse.Add(nameProdus);
            Save();
        }

        /// <summary>
        /// Metoda care salveaza produsul nou adaugat si rescrie fisierul respectiv
        /// </summary>
        public void Save()
        {
            StreamWriter wr = new StreamWriter(FolderProduse + "produse.txt");
            foreach (String st in _produse)
            {
                wr.WriteLine(st);
            }
            wr.Close();
        }

        /// <summary>
        /// Metoda care sterge un anumit produs din lista 
        /// </summary>
        /// <param name="nameProdus"></param>
        public void DeleteProdus(string nameProdus)
        {
            int i;
            for (i = 0; i < _produse.Count; ++i)
            {
                if (_produse[i] == nameProdus)
                {
                    _produse.RemoveAt(i);
                }
            }
            Save();
        }
    }
}
