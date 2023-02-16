﻿namespace BoulangerieEtArroseur.Compteur.Source
{
    class Champ
    {
        /**
         * Une parcelle contient soit : 
         * - un plant, noté "x"
         * - un arroseur, noté "o"
         * Exemple pour une parcelle 3*3 :
         *      x x x
         *      x o x
         *      x x x
         * Cette parcelle contient 8 plants et 1 arroseur
         * 
         * Pour obtenir l'élément à la position [0, 0] : parcelle[0, 0]
         * Pour obtenir le nombre de lignes : parcelle.GetLength(0)
         * Pour obtenir le nombre de colonnes : parcelle.GetLength(1)
         */
        char[,] parcelle;
        char arroseur = 'o';
        char plant = 'x';
        public Champ(char[,] parcelle)
        {
            this.parcelle = parcelle;
        }

        public int Tableau(char valeur)
        {
            int nbColonnes = parcelle.GetLength(1);
            int nbLignes = parcelle.GetLength(0);


            int occurence = 0;

            for (int i = 0; i < nbColonnes; i++)
            {
                for (int j = 0; j < nbLignes; j++)
                {
                    if (parcelle[j, i] == valeur)
                    {
                        occurence++;
                    }
                }
            }
            return occurence;
        }
        /**
         * Renvoie le nombre d'arroseurs présents dans la parcelle
         * Les arroseurs sont représentés par la lette "o"
         */
        public int GetNombreArroseurs()
        {
            return Tableau(arroseur);
        }
        /**
         * Renvoie le nombre de plants présents dans la parcelle
         * Les plants sont représentés par la lettre "x"
         */
        public int GetNombrePlants()
        {
            return Tableau(plant);
        }

        /**
         * Renvoie le nombre de plants arrosés dans la parcelle
         * Les plants sont représentés par la lettre "x"
         * On considère qu'un plant est arrosé s'il se trouve dans une case
         * adjacente à un arroseur.
         * Les diagonales comptent, donc un arroseur peut arroser jusqu'à 8 plants
         */
        public int GetNombrePlantsArroses()
        {
            int nbColonnes = parcelle.GetLength(1);
            int nbLignes = parcelle.GetLength(0);

            int plantArroses = 0;
            for (int i = 0; i < nbColonnes; i++)
            {
                for (int j = 0; j < nbLignes; j++)
                {
                    if (parcelle[j, i] == arroseur)
                    {
                        for (int k = -1; k < 2; k++)
                        {
                            for (int l = -1; l < 2; l++)
                            {
                                int n = i + k;
                                int m = j + l;
                                if (n >= 0 && n < nbColonnes)
                                {
                                    if (m >= 0 && m < nbLignes)
                                    {
                                        if (parcelle[m, n] == plant)
                                        {
                                            parcelle[m, n] = 'z';
                                            plantArroses++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return plantArroses;
        }
    }
}