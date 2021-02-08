/* ===================================================================
 * Worksheet: |  Lab5_methods
 * Program:   |  lab5_methods_q5_results_of_calls
 * Author:    |  Leigh McGuinness - s00183063
 * Date:      |  06/02/21
 * ===================================================================*/

/*
 * 5. Consider these methods:
static double f(double x) {return g(x)+Math.Sqr(h(x));}
static double g(double x) {return 4 * h(x);}
static double h(double x) {return x * x + k(x) – 1;}
static double k(double x) {return 2 * (x +1);}

Determine the results of the following method calls:
a) double x1 = k(2);
    x1 = 2 * (2 + 1) 
       = 2 * 3 
       = 6

b) double x2 = h(2);
    x2 = 2 * 2 + 2 * (2 + 1) - 1
       = 4 + 2 * 3 - 1
       = 4 + 6 - 1
       = 10 - 1
       = 9

c) double x3 = g(2) + h(2));
    x3 = 4 * 9  + 9
       = 36 + 9
       = 47

d) double x4 = f(2);
    x4 = 4 * 9 + sq,rt(9)
       = 36 + 3
       = 39
 */