   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC"   SISJORSAC.FrmListadoContrato   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	     � Title$  Listado de Contratos��5   	   $��651.045��6&   $��1204.337��67    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.   .��5
      � .+�5   
   �� -   5         ��Name$ lblBusqueda��5      $8��2Buscar por Número de Contrato/Dirección de Obra:��6%   $
��Left=�6`   $��	28,22,0,0q�6{   $	��Top=�6�   $	��312��6�   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgvListadoContrato��5      $
��Left=�61   $��
28,111,0,0q�6L   $	��Top=�6`   $	��362��6x   $
��1124��6�      AutoGenerateColumns .     GridLinesVisibility$	 All=�6�   $��1q�6�   �� 5   
   -   5         ��Name$ txtBusqueda��5      $
��Left=�6'   $��23��6B   $��
345,22,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��225��6�   6�   �� 5   
   -   5        	 ��Name$	 btnVerDetalle��5      $��Ver Detalle��6(   $
��Left=�6>   $��528,510,0,0q�6Y   $	��Top=�6n   $	��103��6�   ���	#FF39A3D4$
��Bold"�6�   
�������6�   5      5      