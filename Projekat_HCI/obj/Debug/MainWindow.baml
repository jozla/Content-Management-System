   M S B A M L   `   `   `  ����G  CProjekat_HCI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Projekat_HCIProjekat_HCI  5   	       Projekat_HCI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Projekat_HCI     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowStyle$
 None=�6f    � AllowsTransparency . 
������  � WindowStartupLocation$ CenterScreen=�6�    � 	Resources 5
       �� 
TargetType   RoundButton �� Property �� Value �� 	Resources��%�  &	        �� 5   
   " ��6   .�5      ��  � ��
 �����6;   �� 5       � ��$	 100��6'   �� 5       � ��$ 35��6(   �� 5       �@�Cursor$
 Hand��6(   �� 5       � ��$ 20(�6)   �� 5       � ��$
 Bold"�6+    5      ���� 5      '��       " ��6   .�5      ��  �@��CornerRadius$ 5��65   �� 5       � ��
 �����63   5      5      5      5      .��5      �� $	��350��6   $	��550��6   .+�5   
   F� -   5        $��UIPath��5   1   
�������$��2��6   ��5      �� 5      	 �� ImageSource$!	 other_images/background.jpg��6   6I   ��5      B� 5       .��5!      E� 
 E� 
StartPoint$

 50,0&�6!   .��5"      ��  �� Size$ 50,65��6%    �� RotationAngle$	 180Q�62    �� SweepDirection$ CounterClockwise=�6F    �� Point$
 0,50&�6h   �� 5#       �� Point$ 0,300&�6&   �� 5$      $ 50,65��6%   $	 180Q�62   $ CounterClockwise=�6G   $ 50,350&�6i   �� 5%      $ 500,350&�6&   �� 5&      $ 50,65��6%   $	 180Q�62   $ CounterClockwise=�6G   $ 550,300&�6i   �� 5'      $ 550,50&�6&   �� 5(      $ 50,65��6%   $	 180Q�62   $ CounterClockwise=�6G   $ 500,0&�6i   �� 5)      $
 50,0&�6&   5*      5+      5-      �� 5/   
   $
��50px(�6    �� Left$	 200��6    
 �� Top$ 40��62   
�������$��	ExtraBold"�6U   $	��150��6l   .��6x   Login6   �� 50   
   -   5         ��Name$ emailTextBox��50      $	��250��6(   $��30��64   $	 150��6@   $	 140��6R   $��20(�6c   6�   G� 52   
   -   5         G�Name$ passwordTextBox��52      $	��250��6/   $��30��6;   $	 150��6G   $	 190��6Y   $��20(�6j   6�   �� 53   
   -   5         ��Name$ 
errorLabel��53      $	��250��6$   $��50��60   $��15(�6<   $��	ExtraBold"�6J   $	 150��6a   $	 220��6s   
���  ��6�   �� 54   
   -   5         ��Name$ loginButton��54      $	 300��6&   $	 280��68   #���   6J   .��6�   Login6�   �� 55   
   -   5        $	 150��55      $	 280��6$   #���   66   .��6v   Exit6|   57      58      