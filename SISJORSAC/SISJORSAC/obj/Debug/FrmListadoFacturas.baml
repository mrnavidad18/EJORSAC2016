   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC"   SISJORSAC.FrmListadoFacturas   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	     � Title$  Consulta - Facturas��5   	   $��482.126��6%   $��1108.944��66    � 
ResizeMode$ NoResize=�5   
    � WindowStartupLocation$ CenterScreen=�5	   	   .��5      � $��-9,0,9,0q�6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
dgvListado��5      $��Right=�6(   $	��Top=�6F   $��
0,106,10,0q�6_   $
��1071��6s   $	��227��6�   ���	#FFB8B6B6   AutoGenerateColumns .     CanUserAddRows .     SelectionMode$ Single=�5         CanUserDeleteRows .    CanUserResizeRows .  	   CanUserSortColumns	 .  
   HeadersVisibility$
 Column=�5         GridLinesVisibility$	 All=�5         SelectionUnit$ FullRow=�5      ���	#FFA8A8A8$��1q�5         AlternatingRowBackground �	#FF84CFCF   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      -   5        
NROFACTURA��,  &System.Windows.Controls.DataGridColumn   Header$ 	N° COMP.��5   9      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6K   ��  �� Path$ NRO_FACTURA�6p     5      -   5        RAZONSOCIAL��$ CLIENTE - RAZON SOCIAL��5   :    .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 400 6�    6Z   �� $ cliente.RAZON_SOCIAL�6�     5      -   5        FECHAEMISION��$ FECHA EMISION��5   ;    . $	 200 6�    6R   �� $ FECHA_EMISION� �� StringFormat$ {0:dd/MM/yyyy}��6�     5      -   5        	TOTAL��$ 
TOTAL FAC.��5   4    . $	 150 6y    6H   �� $ TOTAL�6y     5       -   5        ACUENTA��$
 DEBE��5    6    . $	 150 6u    6D   �� $ SALDO�6u     5!      -   5        	CANCELADO��$ ESTADO��5!   8    . $ * 6}    6H   �� $ 	CANCELADO�6}   5$      �� 5%   
   $��Buscar por:��6   $
��Left=�6(   $��	22,23,0,0q�6C   $	��Top=�6V   $
��1071��6n   $��74��6{   (  "System.Windows.Controls.DatePicker  5&   
   -   5          Name$ txtFechaHasta��5&      $
��Left=�6,   $��
921,56,0,0q�6G   $	��Top=�6[   $	��140��6s    J� RenderTransformOrigin$ -0.207,2.165&�6   {�.  6�     5'   
   -	   5        $ 
txtFechaDe��5'      $��733,56,235,0q�6)   $	��Top=�6?   6W   �� 5(   
   $��Fecha de Pago  De:��6   $
��Left=�6-   $��31��6H   $��
625,56,0,0q�6T   $	��Top=�6h   $	��112��6�   �� 5)   
   $��Nro. Comp. :��6   $
��Left=�6'   $��	39,56,0,0q�6B   $	��Top=�6U   $��2��6m   �� 5*   
   $��Cliente:��6   $
��Left=�6#   $��31��6>   $��
177,56,0,0q�6J   $	��Top=�6^   $��59��6v   �� 5+   
   $��Hasta:��6   $��31��6!   $��868,56,187,0q�6-   $	��Top=�6C   �� 5,   
   -
   5         ��Name$ 
txtNroComp��5,      $
��Left=�6&   $��23��6A   $��
116,56,0,0q�6M    �� TextWrapping$
 Wrap=�6a   $	��Top=�6u   $��59��6�   6�   �� 5-   
   -   5         ��Name$ btnVerDetalle��5-      $��Ver Detalle��6(   $
��Left=�6>   $��333,349,0,0q�6Y   $	��Top=�6n   $	��109��6�   ���	#FF3BA9F5
�������$
��Bold"�6�   �� 5.   
   -   5         ��Name$ 
cboCliente��5.      $
��Left=�6'   $��
222,56,0,0q�6B   $	��Top=�6V   $	��199��6n    � ToolTip$ Clientes��6�    �� Text$
 dsds��6�   �� 5/   
   -   5        $ 
btnLimpiar��5/      $��Limpiar��6%   $
��Left=�67   $��664,348,0,0q�6R   $	��Top=�6g   $��75��6   ���	#FFEEE7E7���	#FFF12A2A$
��Bold"�6�   6�   �� 50   
   -   5        $��Salir��50      $
��Left=�6!   $��753,348,0,0q�6<   $	��Top=�6Q   $��75��6i   ���	#FFF12A2A$
��Bold"�6�   
�������6�   �� 51   
   $��Estado:��6   $
��Left=�6"   $��
426,59,0,0q�6=   $	��Top=�6Q   $��62��6i   �� 52   
   -   5        $ 	cboEstado��52      $
��Left=�6&   $��
470,59,0,0q�6A   $	��Top=�6U   $	��155��6m   .@�53      �� $��	CANCELADO��6   �� 54      $��TODOS��6   �� 55      $��	PENDIENTE��6   56      �� 57   
   -   5        $ btnAgregarPago��57      $��Agregar Pago��6)   $
��Left=�6@   $��470,349,0,0q�6[   $	��Top=�6p   $	��168��6�   6�   �� 58   
   -   5        $ 
txtAcuenta��58      $
��Left=�6&   $��23��6A   $��426,399,0,0q�6M   $
 Wrap=�6b   $	��Top=�6v   $	��166��6�   $y�Hidden=�6�   �� 59   
   -   5        $ btnPagar��59      $��Pagar��6#   $
��Left=�63   $��610,396,0,0q�6N   $	��Top=�6c   $��75��6{   $y�Hidden=�6�   5:      5;      