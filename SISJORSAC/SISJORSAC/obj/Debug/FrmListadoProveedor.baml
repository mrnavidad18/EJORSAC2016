   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC#   SISJORSAC.FrmListadoProveedor   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	     � Title$  Listado de Proveedores��5   	   $��583.88��6(   $��1205.83��68    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.   .��5
      � $��0,0,2,4q�6   .+�5   
   �� -   5         ��Name$ lblBusqueda��5      $�� ��6%   $
��Left=�60   $��
354,60,0,0q�6K   $	��Top=�6_   $	��271��6w   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgvListadoProveedor��5      $
��Left=�62   $��
28,132,0,0q�6M   $	��Top=�6a   $	��362��6y   $
��1124��6�      AutoGenerateColumns .     GridLinesVisibility$	 All=�6�   $��1q�6�   6�   �� 5   
   $&�� Seleccione el tipo de Proveedor:��6   $
��Left=�6=   $��
904,28,0,0q�6X   $	��Top=�6l   $��58��6�   $	��234��6�   ���	#CC2871B96�   	� 5   
   -   5         	�Name$ 
rdbNatural��5      $��	NATURALES��6*   $
��Left=�6>   $��
914,58,0,0q�6Y   $	��Top=�6m   $
��Bold"�6�   	� 5   
   -   5        $ rdbJuridica��5      $��	JURIDICOS��6+   $
��Left=�6?   $��1034,58,0,0q�6Z   $	��Top=�6o   $
��Bold"�6�   �� 5   
   -   5         ��Name$ txtBusqueda��5      $
��Left=�6'   $��23��6B   $��
647,60,0,0q�6N   	 �� TextWrapping$
	 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��232��6�   6�   �� 5   
   $
��Left=�6   $��
46,0,0,426q�6+   $	��125��6?   $	��121��6K   $��Bottom=�6X   $
��Fill=�6s   $��IMG/logo_rep.PNG��6�   �� 5   
   $��Listado de Proveedores��6   $
��Left=�61   $��
443,10,0,0q�6L   $	��Top=�6`   $
��Bold"�6x   $��37��6�   $	��272��6�   $��22(�6�   ��6�   Z� 6�   5      5      