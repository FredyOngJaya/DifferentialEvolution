using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DifferentialEvolution
{
    class DifferentialEvolution
    {
        //k = index kind of crews
        /*
         * k = 1,...,K
         * k = 1 pilot F-100, k = 2 pilot Pilot CN-235
         * and k = 8 is for stewardess and etc.
         */
        //i = index numbers of crew
        /*
         * 1,...,m[k]
         * m5 = 17 is the number of crew members for Boeing 737-200
         * m8 = 55 is the number of stewardess of Boeing 737-200
         */
        //j = index rotating/pairing
        /*
         * index rotation/pairing which assigned to crew members (1,...,n[k])
         * n5 = 82, is the number of pairings for Being 737-200
         */
        //l = number of days in month ? (1,...,31)
        //d[j][k]
        //p[i][l][k]
        //q[j][l][k]
        //d[max,k]
        //v[j][k]
        //v[max,k]
        //D[min,[j][k]]
        //t[j][k]
        //t[max,k]
        //n[r][s][k]

        const int k = 6;
        int[] m = new int[k] { 5, 4, 3, 6, 17, 55 };
        int[] n = new int[k] { 4, 8, 10, 13, 82, 114 };
        int[] d = new int[k] { 110, 110, 110, 110, 110, 120 };
        int[] t = new int[k] { 21, 21, 21, 21, 21, 21 };
        int[] v = new int[k] { 90, 90, 90, 90, 90, int.MaxValue };

        public void optimize()
        {
        }

        public void ObjectiveFunctions()
        {
            //cost of roster
            //min for i = 1...m[k] for j = 1...n[k] d[j][k]x[i][j][k]


        }
    }
}
