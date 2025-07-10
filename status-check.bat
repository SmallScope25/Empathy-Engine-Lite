@echo off
echo 🔍 EMPATHY ENGINE STATUS CHECK
echo ================================================================================================
echo.

echo 📁 CURRENT DIRECTORY:
cd
echo.

echo 🌿 GIT BRANCH STATUS:
git branch
echo.

echo 📊 GIT STATUS:
git status
echo.

echo 📋 LAST 3 COMMITS:
git log --oneline -3
echo.

echo 🎯 UNITY PROJECT LOCATION:
if exist "Assets" (
    echo ✅ Unity Assets folder found - you're in a Unity project
) else (
    echo ❌ No Unity Assets folder - you might be in the wrong directory
)
echo.

echo ================================================================================================
echo 💡 QUICK COMMANDS:
echo - Import module: Add .cs file to Unity, test compilation, then run quick-commit
echo - Finish phase: ./complete-phase.bat "PHASE NAME"  
echo - Check this status: ./status-check.bat
echo - Emergency help: ./rollback-help.bat
echo ================================================================================================