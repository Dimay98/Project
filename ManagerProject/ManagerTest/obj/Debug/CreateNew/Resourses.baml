   M S B A M L   `   `   `  ����F  BManagerTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:ManagerTest.CreateNewManagerTest.CreateNew  5   	   %    ManagerTest.CreateNew.Resourses   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:ManagerTest.CreateNew     5   	     � Title$T  NСистема контроля и распределения ресурсов��5   
   $	��350��6<   $	��500��6I    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       �� 5
   
   " ��6   .�5      ��  � ��$ 	20 8 20 8q�6'   �� 5       � ��$	 100��6&   �� 5       � ��$ 30��6'   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ ResourseGrid��5   /      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Название��6>   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 100 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Name+6P     5      $!	 Серийный номер��6A   $	
 125 6Y    6%   �� *	SerialN+6Y     5      $#	 Время занятости��6>   $	
 120 6W    6%   �� *Time+6W     5      $)	 #Цель использования��6F   $	
 160 6b    6%   �� *PurposeToUse+6b   5      �� 5   
   $��Center=�6   $��1��63    �� Orientation$ 
Horizontal=�6@   .+�5      �� -   5         ��Name$ CreateButton��5      $��Добавить��6+   6>   �� 5       -   5        $ updateButton��5       $��Обновить��6+   6>   �� 5!      -   5        $ deleteButton��5!      $��Удалить��6+   6=   5"      5#      5$      