/**************************************************************************
 *                                                                        *
 *  File:        IManagement.cs                                           *
 *  Copyright:   (c) 2022, Alexandra-Catalina Poleac                      *
 *  Description: Aplicatie pentru administrare magazin de cosmetice       *
 *                                                                        *
 *                                                                        *
 **************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management
{
    /// <summary>
    /// Interfata pentru managementul produselor
    /// </summary>
    public interface IManagement
    {
        /// <summary>
        /// Metoda care returneaza numarul de produse din lista
        /// </summary>
        /// <returns>Numarul produselor din lista</returns>
        int ListCount();

        /// <summary>
        /// Metoda care returneaza lista cu numele produselor
        /// </summary>
        /// <returns>Lista cu numele produselor din magazinul de cosmetice</returns>
        string[] ListAll();

        /// <summary>
        /// Metoda care actualizeaza lista cu produse din magazinul de cosmetice
        /// </summary>
        /// <param name="nameProdus"></param>
        void AddProdus(string nameProdus);

        /// <summary>
        /// Metoda care sterge un anumit produs din lista 
        /// </summary>
        /// <param name="nameProdus"></param>
        void DeleteProdus(string nameProdus);
    }
}
