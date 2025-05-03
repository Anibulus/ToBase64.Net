# ToBase64.Net

This tool allows you to integrate a small program to encode files to `base64` and setup with your terminal.

First build and test
```bash
dotnet build
dotnet run --project Main/Main.csproj
```

Then publish to get the `.dll`
```bash
dotnet publish -o ./publish 
```

Now add the path of the dll to your `bashrc`
```bash
echo alias toBase64=\"dotnet your_path/ToBase64.Net/publish/Main.dll\" >> ~/.bashrc
```

```bash
source ~/.bashrc
```

Now you are able to encode files
```bash
toBase64 <your_path_file>
```