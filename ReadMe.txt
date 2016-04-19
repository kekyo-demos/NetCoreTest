■以下の dotnet で確認

>dotnet --version

.NET Command Line Tools (1.0.0-beta-001598)

Product Information:
 Version:     1.0.0-beta-001598
 Commit Sha:  7582649f88

Runtime Environment:
 OS Name:     Windows
 OS Version:  10.0.10586
 OS Platform: Windows
 Runtime Id:  win10-x64

■実行方法
cd WithEmit
dotnet restore
dotnet build

NetCoreTest.sln を開く。
ここで、Win8UnitTestでWithEmit.dllが見えないって言われたら、WithEmit\bin\Debug\WithEmit.dllを参照
ユニットテストを実行。