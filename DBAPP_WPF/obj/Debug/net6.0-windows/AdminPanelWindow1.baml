   M S B A M L   `   `   `  ����D  @DBAPP_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:DBAPP_WPF	DBAPP_WPF  5   	   !    DBAPP_WPF.AdminPanelWindow1   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:DBAPP_WPF     5   	   -   5        $	��400��5   	   $	��650��6      
adminPanel  � Title#  �   5	   	   $	��450��6.   $	��800��6;   .��5
      (� .��5   
   � $	��450��6   $	��800��6   .+�5      �� .@�5      ��   userOptions#���  6   $��18(�6A   .��5      � ���	#FFE5E5E5.+�5      �� -   5         ��Name$ UsernameListBox��5   "   $��36,63,558,219q�6f   6}   �� 5      -   5        $ AccessLevel1ListBox��5   "   $��278,63,429,269q�6j   �� 5      -   5         ��Name$ Password1TextBox��5   "   $
��Left=�6<   $��
36,246,0,0q�6W    �� TextWrapping$
 Wrap=�6k   $	��Top=�6   $	��200��6�   �� 5        username#���  6    $
��Left=�6E   $��	36,22,0,0q�6`   $	��Top=�6s   $	��127��6�   �� 5        	accessLvl#���  6    $
��Left=�6F   $	��Top=�6a   $	��132��6y   $��
256,22,0,0q�6�   $��18(�6�   �� 5        password#���  6    $
��Left=�6E   $��
36,207,0,0q�6`   $	��Top=�6t   $	��120��6�   �� 5      -   5         ��Name$ DeleteUserButton��5   !     
deleteUser#���  6;   $
��Left=�6b   $��
36,295,0,0q�6}   $	��Top=�6�   $	��147��6�   $��32��6�   $��18(�6�   6�   �� 5      -   5        $ SaveChangesUserButton��5   !     saveChanges#���  6@   $
��Left=�6h   $��218,295,0,0q�6�   $	��Top=�6�   $	��147��6�   $��32��6�   $��18(�6�   6�   �� 5      #���  6    $
��Left=�6R   $��Center=�6m   $	��138��6�   $��	629,0,0,0q�6�   $��18(�6�   �� 5      #���  6    $
��Left=�6Q   $��
629,22,0,0q�6l   $	��Top=�6�   $	��138��6�   �� 5      -   5        $ UsernameTextBox��5   "   $
��Left=�6;   $��
629,63,0,0q�6V   $
 Wrap=�6j   $	��Top=�6~   $	��138��6�   �� 5      -   5        $ AccessLevel2ListBox��5   "   $��629,229,78,103q�6j   �� 5      #���  6    $
��Left=�6Q   $��629,112,0,0q�6l   $	��Top=�6�   $	��120��6�   �� 5      -	   5        $ Password2TextBox��5   "   $
��Left=�6<   $��629,152,0,0q�6W   $
 Wrap=�6l   $	��Top=�6�   $	��138��6�   �� 5      -
   5        $ CreateUserButton��5   !     
createUser#���  6;   $
��Left=�6b   $��629,334,0,0q�6}   $	��Top=�6�   $	��138��6�   $��32��6�   $��18(�6�   6�   5      5      �� 5         accessLvlOptions#���  6   $��18(�6F   .��5!      � ���	#FFE5E5E5.+�5"      �� -   5        $ Functions1CheckedListBox��5"   "    �� SelectionMode$ Multiple=�6D   $��82,184,547,91q�6]   �� 5#      -   5        $ Functions2CheckedListBox��5#   "   $ Multiple=�6D   $��543,184,86,91q�6]   �� 5$      -   5        $ ChangeAccessLevelListBox��5$   "   $��82,47,614,284q�6o   6�   �� 5%       	 permittedFunctions#��� 	 6    $
��Left=�6O   $��
82,143,0,0q�6j   $	��Top=�6~   $	��165��6�   �� 5&      #���  6    $
��Left=�6F   $��82,8,0,0q�6a   $	��Top=�6s   $	��141��6�   �� 5'      #���  6    $
��Left=�6F   $��
543,18,0,0q�6a   $	��Top=�6u   $	��165��6�   �� 5(      #��� 	 6    $
��Left=�6O   $��543,143,0,0q�6j   $	��Top=�6   $	��165��6�   �� 5)      -   5        $ AccessLevelTextBox��5)   "   $
��Left=�6>   $��
543,63,0,0q�6Y   $
 Wrap=�6m   $	��Top=�6�   $	��165��6�   �� 5*      -   5        $ DeleteLvlButton��5*   !    
 	deleteLvl#��� 
 6:   $
��Left=�6`   $��
201,63,0,0q�6{   $	��Top=�6�   $��40��6�   $	��165��6�   6�   �� 5+      -   5        $ SaveLvlChangesButton��5+   !   #���  6?   $
��Left=�6g   $��
94,349,0,0q�6�   $	��Top=�6�   $��42��6�   $	��141��6�   6�   �� 5,      -   5        $ CreateLvlButton��5,   !     	createLvl#���  6:   $
��Left=�6`   $��523,349,0,0q�6{   $	��Top=�6�   $��42��6�   $	��205��6�   6�   5-      5.      5/      50      51      52      