   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC   SISJORSAC.FrmListadoGasto   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	     � Title$  Listado de Gastos��5   	   $��651.045��6#   $��1204.337��64    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.   .��5
      � .+�5   
   �� -   5         ��Name$ lblBusqueda��5      $7��1Buscar por Número de Gasto /Nro Doc. Referencia:��6%   $
��Left=�6`   $��
513,81,0,0q�6{   $	��Top=�6�   $	��307��6�   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgvListadoGasto��5   6   $
��Left=�6O   $��
28,126,0,0q�6j   $	��Top=�6~   $	��258��6�   $
��1099��6�      AutoGenerateColumns .     GridLinesVisibility$	 All=�6�   $��1q�6�      
IsReadOnly . 6�   �� 5   
   -   5         ��Name$ txtBusqueda��5      $
��Left=�6'   $��23��6B   $��
825,81,0,0q�6N   	 �� TextWrapping$
	 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��302��6�   6�     5   
   -   5        $ dgvListadoDetalleGasto��5      $
��Left=�65   $��
28,413,0,0q�6P   $	��Top=�6d   $	��197��6|   $
��1099��6�    .  $	 All=�6�   $��1q�6�    . 6�   �� 5   
   $
��Left=�6   $��
10,0,0,499q�6+   $	��125��6?   $	��121��6K   $��Bottom=�6X   $
��Fill=�6s   $��IMG/logo_rep.PNG��6�   �� 5   
   $��Listado de Gastos��6   $
��Left=�6,   $��
336,10,0,0q�6G   $	��Top=�6[   $
��Bold"�6s   $��37��6�   $	��272��6�   $��22(�6�   ��6�   Z� 6�   5      5      