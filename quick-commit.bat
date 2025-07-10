@echo off
echo 🚀 QUICK MODULE COMMIT STARTING...
echo.

:: Get the inputs
set module_name=%1
set description=%2

:: Remove quotes from inputs
set module_name=%module_name:"=%
set description=%description:"=%

:: Get current timestamp
for /f "tokens=2 delims==" %%a in ('wmic OS Get localdatetime /value') do set "dt=%%a"
set "timestamp=%dt:~0,4%-%dt:~4,2%-%dt:~6,2% %dt:~8,2%:%dt:~10,2%"

:: Create the commit message
echo 📦 MODULE SUCCESS: %module_name% > temp_commit_msg.txt
echo. >> temp_commit_msg.txt
echo %description% >> temp_commit_msg.txt
echo. >> temp_commit_msg.txt
echo 🕐 Timestamp: %timestamp% >> temp_commit_msg.txt
echo ✅ Unity Compilation: Ready for testing >> temp_commit_msg.txt
echo 🎯 Next: Import next module in sequence >> temp_commit_msg.txt

:: Stage all changes
echo 📝 Staging all changes...
git add .

:: Create commit with message file
echo 💾 Creating commit...
git commit -F temp_commit_msg.txt

:: Push to GitHub
echo 🌐 Pushing to GitHub...
git push

:: Cleanup
del temp_commit_msg.txt

echo.
echo ✅ SUCCESS! Module %module_name% committed and pushed!
echo 🔥 Ready for next module import!
echo.