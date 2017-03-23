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

