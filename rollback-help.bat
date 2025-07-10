@echo off
echo 🚨 EMERGENCY ROLLBACK HELPER
echo.
echo This will show your recent commits so you can choose which one to rollback to.
echo.
echo 📋 YOUR RECENT COMMITS:
echo ================================================================================================
git log --oneline -10
echo ================================================================================================
echo.
echo 🎯 TO ROLLBACK TO A SPECIFIC COMMIT:
echo 1. Find the commit hash (letters/numbers on the left)
echo 2. Run: git reset --hard [commit-hash]
echo 3. Run: git push --force-with-lease
echo.
echo ⚠️  WARNING: This will permanently delete all changes after that commit!
echo 💡 TIP: Only use this if something is seriously broken
echo.
echo 🔒 SAFER OPTION: Create a new branch to experiment:
echo git checkout -b fix-attempt
echo (Then you can always switch back to main branch)
echo.