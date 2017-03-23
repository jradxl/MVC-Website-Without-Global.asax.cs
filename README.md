# MVC-Website-Without-Global.asax.cs
ASP.NET MVC Website which uses a HTTPModule as it's startup

From this Article,
http://erraticdev.blogspot.co.uk/2011/01/how-to-correctly-use-ihttpmodule-to.html
and various others.

Shows that a MVC 2/3/4 Website does not need a Global.aspx.cs to start up.
(It does still need Global.aspx with just a simple minimal one line - I don't know if this can be eliminated.)

Also demonstrates PreApplicationStartMethod
http://blog.davidebbo.com/2011/02/register-your-http-modules-at-runtime.html
and various others.

See the Diagnosic.Debug messages in output window.

There are various questions on StackOverflow as to the startup order.
Seems to me that the Modules are loaded in the order they are put in web.config.
It would make sense therefore, to put first the Startup Module which has the stuff from Global.aspx.cs

Branch
--original code with the startup code in DemoModules.Startup1

Master
--startup code now in PreApplicationStartMethod, but with a semiphore to endure run only once.
  it seems that the website will work with Routing loaded here.
  so this repreents the earliest point in the life-cycle.
  

//2017-03-22
