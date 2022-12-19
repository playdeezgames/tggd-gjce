dotnet publish ./src/tggd_jgce/tggd_jgce.vbproj -o ./pub-linux -c Release --sc -r linux-x64
dotnet publish ./src/tggd_jgce/tggd_jgce.vbproj -o ./pub-windows -c Release --sc -r win-x64
butler push pub-windows thegrumpygamedev/tggd-jgce:windows
butler push pub-linux thegrumpygamedev/tggd-jgce:linux
git add -A
git commit -m "shipped it!"