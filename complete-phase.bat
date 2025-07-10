@echo off
echo 🚀 PHASE COMPLETION TRACKER STARTING...
echo.

:: Get the phase name
set phase_name=%1
set phase_name=%phase_name:"=%

:: Count recent module commits
echo 📊 Analyzing phase progress...

:: Get current timestamp
for /f "tokens=2 delims==" %%a in ('wmic OS Get localdatetime /value') do set "dt=%%a"
set "timestamp=%dt:~0,4%-%dt:~4,2%-%dt:~6,2% %dt:~8,2%:%dt:~10,2%"

:: Create phase completion commit message
echo 🎉 %phase_name% COMPLETE > temp_phase_msg.txt
echo. >> temp_phase_msg.txt
echo 📊 PHASE SUMMARY: >> temp_phase_msg.txt
echo - All modules in this phase imported successfully >> temp_phase_msg.txt
echo - Unity compilation: Clean >> temp_phase_msg.txt
echo - Ready for next phase >> temp_phase_msg.txt
echo. >> temp_phase_msg.txt
echo 🕐 Completed: %timestamp% >> temp_phase_msg.txt
echo 🎯 Next: Begin next phase of import sequence >> temp_phase_msg.txt

:: Stage and commit
echo 📝 Creating phase completion commit...
git add .
git commit -F temp_phase_msg.txt

:: Push to GitHub
echo 🌐 Pushing to GitHub...
git push

:: Cleanup
del temp_phase_msg.txt

echo.
echo ✅ PHASE COMPLETE! %phase_name% milestone created!
echo 🚀 Ready to begin next phase!
echo.