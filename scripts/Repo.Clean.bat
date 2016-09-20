@SETLOCAL ENABLEEXTENSIONS
@SETLOCAL ENABLEDELAYEDEXPANSION

@CD /d "%~dp0"

@ECHO OFF

SET isAdmin=0
WHOAMI /all | FINDSTR /c:" S-1-16-12288 "> NUL && SET isAdmin=1

IF "%isAdmin%" == "0" (
	ECHO You must be the Administrator to run this script
	PAUSE
)

IF "%isAdmin%" == "1" (

	cd ..\ > NUL
	
	ECHO Stopping IIS... 
	iisreset /stop > NUL

	ECHO Cleaning repo... 
	git clean -q -xdf > NUL

	ECHO Resetting repo... 
	git reset -q --hard HEAD > NUL

	IF EXIST node_modules (
		ECHO Removing node modules... 
		rmdir /s /q "src\AgeBaseTemplate.Client\node_modules" > NUL
	)

	ECHO Installing node modules... 
	cd src\AgeBaseTemplate.Client > NUL
	call npm -s install > NUL
	cd ..\ > NUL

	ECHO Running gulp less task... 
	cd src\AgeBaseTemplate.Client > NUL
	call gulp debug > NUL
	cd ..\ > NUL

	ECHO Restoring database... 
	cd scripts > NUL
	call Restore.bat > NUL
	cd ..\ > NUL

	ECHO Restoring nuget packages... 
	tools\NuGet\nuget.exe restore src\AgeBaseTemplate.sln > NUL

	ECHO Building application... 
	msbuild src\AgeBaseTemplate.sln /p:Configuration=Debug > NUL

	ECHO Starting IIS... 
	iisreset /start > NUL

	ECHO Opening browser... 
	start https://agebasetemplate.local/ > NUL

	cd scripts > NUL
)