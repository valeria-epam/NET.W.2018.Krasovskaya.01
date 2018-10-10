csc.exe /t:module Laptop.cs
csc.exe /t:module Tablet.cs
csc.exe /t:module Phone.cs

sn.exe -k keypair.snk

csc.exe /t:library /addmodule:Laptop.netmodule /addmodule:Tablet.netmodule /addmodule:Phone.netmodule /out:Gadgets.dll /keyfile:keypair.snk 

gacutil -i Gadgets.dll
