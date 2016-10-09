

@ECHO OFF

nuget "pack" "..\Microsoft.Owin.Security.Tencent.QQ\Microsoft.Owin.Security.Tencent.QQ.csproj" -Prop Configuration=Release
nuget "pack" "..\Microsoft.Owin.Security.Tencent.Wechat\Microsoft.Owin.Security.Tencent.Wechat.csproj" -Prop Configuration=Release
nuget "pack" "..\Microsoft.Owin.Security.Sina.Weibo\Microsoft.Owin.Security.Sina.Weibo.csproj" -Prop Configuration=Release

pause