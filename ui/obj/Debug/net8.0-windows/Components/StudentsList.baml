   M S B A M L   `   `   `  ����=  9UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:UI.ViewModelUI.ViewModel  5      %clr-namespace:UI.Extras	UI.Extras  5           UI.Components.StudentsList   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0	viewModelclr-namespace:UI.ViewModel     5      )localclr-namespace:UI.Extras     5        � 	Resources  5      #   UI.Extras.AgeToBrushConverter   AgeToBrushConverter  AgeBasedRowStyle �� 
TargetType)  #System.Windows.Controls.DataGridRow �� Property �� Value �� 	Converter��%�   &	        &	      7     5   
   6$   �� 5   
   "  6)   .�5      ��  � �� 6+   �� *Age+8   5      5      .��5      � .+�5   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns$ False��5         
IsReadOnly$
 True��5      $��5q�5         RowStyle# [ 5      ��5      �� *StudentUsers+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6%   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *Id+  5      $
	 Name��6%   
 63   �� *Name+  5      $	 Password��6%   
 67   �� *
Password+  5      $
	 Role��6%   
 63   �� *Roles+  5      $		 Age��6%   
 62   �� *Age+  5      $	 Expires��6%   
 66   �� *	Expires+5!      5"      5#      