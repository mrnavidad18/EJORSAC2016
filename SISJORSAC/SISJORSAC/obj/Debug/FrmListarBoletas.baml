   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC    SISJORSAC.FrmListarBoletas   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	     � Title$  Listado de Boletas��5   	   $��417.626��6$   $��838.638��65    � WindowStartupLocation$ CenterScreen=�5       � 
ResizeMode$ NoResize=�6<   .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgvListado��5      $��Right=�6(   $	��Top=�6F   $��	0,106,0,0q�6_   $	��781��6r   $	��227��6~   ���	#FFB8B6B6   AutoGenerateColumns .     CanUserAddRows .     SelectionMode$ Single=�5         CanUserDeleteRows .    CanUserResizeRows .  	   CanUserSortColumns	 .  
   HeadersVisibility$
 Column=�5         GridLinesVisibility$	 All=�5         SelectionUnit$ FullRow=�5      ���	#FFA8A8A8$��1q�5         AlternatingRowBackground �	#FF84CFCF   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        	NROBOLETA��,  &System.Windows.Controls.DataGridColumn   Header$ 	N° COMP.��5   8      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   ��  �� Path$ 
NRO_BOLETA�6o     5      -   5        RAZONSOCIAL��$ CLIENTE - RAZON SOCIAL��5   :    .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 450 6�    6Z   �� $ RAZONSOCIAL_NOMBRES�6�     5      -   5        FECHAEMISION��$ FECHA EMISION��5   ;    .  6R   �� $ FECHA_EMISION� �� StringFormat$ {0:dd/MM/yyyy}��6�     5      -   5        	TOTAL��$ 
TOTAL BOL.��5   4    . $ * 6y    6H   �� $ TOTAL�6y   5       �� 5!   
   $��Buscar por:��6   $
��Left=�6(   $��	10,23,0,0q�6C   $	��Top=�6V   $	��811��6n   $��74��6z   (  "System.Windows.Controls.DatePicker  5"   
   -   5          Name$ txtFechaHasta��5"      $
��Left=�6,   $��
697,56,0,0q�6G   $	��Top=�6[   $	��124��6s    J� RenderTransformOrigin$ -0.207,2.165&�6   {�.  6�     5#   
   -   5        $ 
txtFechaDe��5#      $��524,59,180,0q�6)   $	��Top=�6?   6W   �� 5$   
   $��Fecha de Pago  De:��6   $
��Left=�6-   $��31��6H   $��
414,56,0,0q�6T   $	��Top=�6h   $	��112��6�   �� 5%   
   $��Nro. Comp. :��6   $
��Left=�6'   $��	17,56,0,0q�6B   $	��Top=�6U   �� 5&   
   $��Cliente:��6   $
��Left=�6#   $��31��6>   $��
180,56,0,0q�6J   $	��Top=�6^   $��59��6v   �� 5'   
   $��Hasta:��6   $��31��6!   $��656,56,96,0q�6-   $	��Top=�6B   �� 5(   
   -   5         ��Name$ 
txtNroComp��5(      $
��Left=�6&   $��23��6A   $��	89,55,0,0q�6M    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $��80��6�   6�   �� 5)   
   -	   5         ��Name$ btnVerDetalle��5)      $��Ver Detalle��6(   $
��Left=�6>   $��333,349,0,0q�6Y   $	��Top=�6n   $	��109��6�   6�   �� 5*   
   -
   5         ��Name$ 
cboCliente��5*      $
��Left=�6'   $��
228,56,0,0q�6B   $	��Top=�6V   $	��180��6n    � ToolTip$ Clientes��6�    �� Text$
 dsds��6�   5,      5-      