@echo off
REM ��ȡ��ǰ BAT �ļ�Ŀ¼
set BASE_DIR=%~dp0

REM ����Ŀ¼���ǵ�ǰĿ¼��Assets/Configs��
set INPUT_DIR=%BASE_DIR%

REM ���Ŀ¼�������Ŀ��Ŀ¼��Assets/Resources/Configs
set OUTPUT_DIR=%BASE_DIR%..\Resources\Configs

REM �������Ŀ¼����������ڣ�
if not exist "%OUTPUT_DIR%" mkdir "%OUTPUT_DIR%"

REM ���� exe
REM ������˫���Ű���·������ֹ�пո��²�����������
if "%INPUT_DIR:~-1%"=="\" set INPUT_DIR=%INPUT_DIR:~0,-1%
if "%OUTPUT_DIR:~-1%"=="\" set OUTPUT_DIR=%OUTPUT_DIR:~0,-1%
REM echo INPUT_DIR=%INPUT_DIR%
REM echo OUTPUT_DIR=%OUTPUT_DIR%
"%BASE_DIR%export_csv.exe" -i "%INPUT_DIR%" -o "%OUTPUT_DIR%"
REM echo "%BASE_DIR%export_csv.exe" -i "%INPUT_DIR%" -o "%OUTPUT_DIR%"

echo.
echo ===== ������� =====
pause