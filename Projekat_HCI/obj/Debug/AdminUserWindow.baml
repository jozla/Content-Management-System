   M S B A M L   `   `   `  ����G  CProjekat_HCI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Projekat_HCIProjekat_HCI  5   	   "    Projekat_HCI.AdminUserWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Projekat_HCI     5   	   -   5          � Title$  AdminUserWindow��5   	   $	��450��6!   $	��800��6.    � WindowStyle$
 None=�6:    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�6�    � 	Resources 5
       �� 
TargetType   RoundButton �� Property �� Value �� 	Resources��%�  &	        �� 5   
   " ��6   .�5      ��  � ��
 �����6;   �� 5       � ��$	 100��6'   �� 5       � ��$ 35��6(   �� 5       �@�Cursor$
 Hand��6(   �� 5       � ��$ 20(�6)   �� 5       � ��$
 Bold"�6+    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$ 5��65   �� 5       � ��
 �����63   5      5      5      5      .��5      �� $	��350��6   $	��550��6   .+�5   
   F� -   5        $��UIPath��5   1   
�������$��2��6   ��5      �� 5      	 �� ImageSource$,	 &other_images/admin_user_background.jpg��6   6T   ��5      B� 5       .��5!      E� 
 E� 
StartPoint$

 50,0&�6!   .��5"      ��  �� Size$ 50,65��6%    �� RotationAngle$	 180Q�62    �� SweepDirection$ CounterClockwise=�6F    �� Point$
 0,50&�6h   �� 5#       �� Point$ 0,300&�6&   �� 5$      $ 50,65��6%   $	 180Q�62   $ CounterClockwise=�6G   $ 50,350&�6i   �� 5%      $ 500,350&�6&   �� 5&      $ 50,65��6%   $	 180Q�62   $ CounterClockwise=�6G   $ 550,300&�6i   �� 5'      $ 550,50&�6&   �� 5(      $ 50,65��6%   $	 180Q�62   $ CounterClockwise=�6G   $ 500,0&�6i   �� 5)      $
 50,0&�6&   5*      5+      5-      �� 5/   
   $
��40px(�6    �� Left$	 130��6    
�������$��	ExtraBold"�6E   $	��290��6\   .��6h   List of movies6x   &   System.Windows.Controls.DataGrid  51   
   -   5          Name$ dataGridFilmovi��51         
IsReadOnly .     AutoGenerateColumns .  $	��200��6|   $	��400��6�   
 �� Top$ 70��6�   $ 75��6�   
������    GridLinesVisibility$	 All=�6�      SelectionMode$ Extended=�6�      CanUserAddRows .  ��6,   �� *	Filmovi+   Columns 52      4  .System.Windows.Controls.DataGridCheckBoxColumn  53      1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *
isSelected+6J   4  .System.Windows.Controls.DataGridTemplateColumn  55      ,  &System.Windows.Controls.DataGridColumn   Header$ Description��6)      
IsReadOnly .    CellTemplate 56      �� 57      .R�58      �� �� 59   "   -   5        .�59   D   .�5:   &   �� 
��� ���$��15(�6^   ��60   �� *
imeFilma+6^   5;   #   5<      5=      5?        5A      $ Image��6)    .  5B      �� 5C      .R�5D      �� $��50��6=   $��50��6H   ��6$   �� *slika+6H   5E      5G      0  *System.Windows.Controls.DataGridTextColumn  5I      $
 Date��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6l    .  63   �� *datum+ �� StringFormat$ {0:dd/MM/yyyy}��6v   5K      �� 5M   
   -   5         ��Name$ deleteButton��5M      $	 380��6'   $	 290��69   #���   6K   .��6�   Delete6�   �� 5N   
   -   5        $ 	addButton��5N      $	 230��6$   $	 290��66   #���   6H   .��6�   Add6�   �� 5O   
   -   5        $ 80��5O      $	 290��6#   #���   65   .��6u   Exit6{   5Q      5R      