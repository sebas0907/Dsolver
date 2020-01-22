# Dsolver
The Ordinary differential equations (ODE) solver uses the Euler's method obtain a numerical solution of coupled or non-coupled differential equations. 
The usual algorithm is summarized as follows:
Given a differential equation of the form x'(t,x) = F(t,x) with initial conditions x(t0) = x0, the function x(t) can be approximated recursively as 

x_(n+1) = x_n + F(x_n, t_n)h

where *h* is the step size of the recursion and t_(n+1) = t_n + h.

## Initializing 
Dsolver already contains as an example the solution the problem:
x''(t) + x(t) + x = 0, with x(0) = x0, and x'(0) = v0, 

this can be thought of as modelling a damped harmonic oscillator. The path to the solution consists in reducing the equation to a coupled system of first order differential equations of the form

v'(t) = -v(t) - x(t) = F1(x, v),

x'(t) = v(t) = F2(x, v).

Thus the Euler´s method is applied by simply *for-looping* the following:
```
double vn = v + F1(x, v) * h;
double xn = x + F2(x, v) * h;
        v = vn;
        x = xn;
```
### Input parameters
As a matter of taste, the various parameters and initial values used are declared via user-input:

`double x`; is initialized as the position at which the system starts.

`double v`; starts as the initial velocity.

`double h`; is the aforementioned stepsize. The smaller the more precise is the programm. However it can never be zero.

`int N`; is the total number of steps in the recursion. 

## Output
The results obtained are not only displayed in the console but also stored in a `.txt` file that could be used to plot graphics.


