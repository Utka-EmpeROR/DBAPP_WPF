   M S B A M L   `   `   `  ����D  @DBAPP_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DBAPP_WPF	DBAPP_WPF  5   	   U QSystem.Runtime, Version=6.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem 5   	       DBAPP_WPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:DBAPP_WPF     5   	   ?System,clr-namespace:System;assembly=System.Runtime     5   	   -   5          �Name$  MyWin��5   	    � Title$ DBAPP��5
   	   $	��450��6   $	��800��6$   $	��400��5   	   $	��650��6    � WindowState$ 	Minimized=�6(   .��5      (� .��5   
   � $	��450��6   $	��800��6   .+�5      �� -   5         ��Name$ UsernameLable��5         username#���   6+   $
��Left=�6\   $��141,116,0,0q�6w   $	��Top=�6�   $��18(�6�   �� 5      -   5         ��Name$ UsernameTextBox��5      $
��Left=�6/   $��340,120,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $	��Top=�6s   $	��215��6�   $��18(�6�   6�   �� 5      -   5        $ PasswordTextBox��5      $
��Left=�6/   $
 Wrap=�6J   $	��Top=�6^   $	��215��6v   $��18(�6�   $��340,208,0,0q�6�   6�   �� 5      -   5        $ PasswordLable��5        password#���  6+   $
��Left=�6P   $��141,197,0,0q�6k   $	��Top=�6�   $��18(�6�   �� 5      -   5         ��Name$ LogInButton��5       	 login#���  6*   $
��Left=�6X   $��364,279,0,0q�6s   $	��Top=�6�   $��38��6�   $	��133��6�   6�   �� 5      -   5         ��Name$ LangComboBox��5      $
��Left=�6-   $��	33,45,0,0q�6H   $	��Top=�6[   $��66��6s    �� 
IsReadOnly$
 True��6~   $��18(�6�   .@�5      ��En��6$   ��5      Ru��6$   5      �� 5      -   5        $ LanguageLable��5        lang#���  6+   $
��Left=�6L   $��33,6,0,0q�6g   $	��Top=�6y   $��18(�6�   �� 5      -	   5        $ LastDBLable��5       
 lastDB#���  6)   $
��Left=�6L   $��126,362,0,0q�6g   $	��Top=�6|   $��14(�6�   $	��138��6�   �� 5      -
   5        $ LastDBTextBox��5      	 �� 
IsReadOnly$
	 True��6-   $
��Left=�6?   $��305,367,0,0q�6Z   $
 Wrap=�6o   $	��Top=�6�   $	��250��6�   $��11(�6�   �� 5      -   5        $ LoadDbButton��5        chooseDB#���  6+   $
��Left=�6P   $��594,360,0,0q�6k   $	��Top=�6�   $��35��6�   $��77��6�   6�   �� 5      -   5        $ AdminPanelButton��5      $
��Left=�60   $��
716,35,0,0q�6K   $	��Top=�6_   $��40��6w   $��40��6�   .��5      �� 
 �� Orientation$
 
Horizontal=�6   .+�5      �� $ ��Resources\optionsImage.jpg��6   5      5      5       5!      5"      