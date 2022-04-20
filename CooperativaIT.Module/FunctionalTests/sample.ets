;#DropDB CooperativaITEasyTest

#Application CooperativaIT.Win
#Application CooperativaIT.Web

*FillForm
 User Name = Admin
*Action Log On

#IfDef CooperativaIT.Win

*Action About...
 
*Action OK

#EndIf

#IfDef CooperativaIT.Web

*Action Choose Theme(Black Glass)

#EndIf
