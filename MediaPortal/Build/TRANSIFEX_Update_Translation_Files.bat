
cd ..\Tools\Transifex\
call tx_2_ToCache.bat
call tx_4_Pull_Translations.bat
call tx_5_Fix_Translations.bat
call tx_6_FromCache.bat
cd ..\..\Build
