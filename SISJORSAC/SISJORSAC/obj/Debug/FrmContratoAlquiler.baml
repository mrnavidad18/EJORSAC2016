   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC#   SISJORSAC.FrmContratoAlquiler   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	   X TXceed.Wpf.Toolkit, Version=2.9.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   -   5          � Title$%  Registro - Contrato de alquiler��5	   	   $��622.425��61   $��976.776��6B    � 
ResizeMode$ NoResize=�6R    � WindowStartupLocation$ CenterScreen=�5   	   .��5      � .+�5   
   �� $
��Left=�6   $	��148��6+   $	��Top=�68   $	��162��6P   $��IMG/logo_rep.PNG��6\   �� 5   
   $��Tipo Compro.:��6   $
��Left=�6(   $��	147,6,0,0q�6C   $	��Top=�6V   �� 5   
   $
��Left=�6   $��23��6-   $��	237,8,0,0q�69    �� TextWrapping$
 Wrap=�6L   $��CONTRATO ALQUILER��6`   $	��Top=�6y   $	��131��6�   {�.  6�   �� 5   
   $��Nro. Contrato:��6   $
��Left=�6)   $��	389,7,0,0q�6D   $	��Top=�6W    J� RenderTransformOrigin$ 0.903,0.444&�6o   �� 5   
   -   5         ��Name$ txtNroContrato��5      $
��Left=�6*   $��23��6E   $��	473,8,0,0q�6Q   $
 Wrap=�6d   $	��Top=�6x   $	��102��6�   {�.  6�   �� 5   
   $��Fech. Emisión:��6   $
��Left=�6)   $��	734,6,0,0q�6D   $	��Top=�6W   $ -0.352,-0.381&�6o   �� 5   
   -   5        $ txtFechaEmision��5      $
��Left=�6+   $��23��6F   $��	818,6,0,0q�6R   $
 Wrap=�6e   $	��Top=�6y   $��83��6�   �� 5   
   $��	Señores:��6   $
��Left=�6#   $��
147,68,0,0q�6>   $	��Top=�6R   �� 5   
   -   5         ��Name$ cboRazonsocial��5      $
��Left=�6+   $��
235,68,0,0q�6F   $	��Top=�6Z   $	��314��6r   6~   �� 5   
   $��	RUC/DNI :��6   $
��Left=�6$   $��
560,68,0,0q�6?   $	��Top=�6S   �� 5   
   -   5        $ 	txtDniRuc��5      $
��Left=�6%   $��23��6@   $��
638,68,0,0q�6L   $
 Wrap=�6`   $	��Top=�6t   $��92��6�   {�.  6�   �� 5   
   -   5        $ txtDireccionObra��5      $
��Left=�6,   $��23��6G   $��253,102,0,0q�6S   $
 Wrap=�6h   $	��Top=�6|   $	��296��6�   �� 5   
   $��Dirección de obra:��6   $
��Left=�6-   $��147,101,0,0q�6H   $	��Top=�6]   �� 5   
   $��	Domicilio��6   $
��Left=�6$   $��559,102,0,0q�6?   $	��Top=�6T   �� 5   
   -   5        $ txtDireccion��5      $
��Left=�6(   $��23��6C   $��638,101,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��265��6�   {�.  6�   �� 5   
   $��Moneda:��6   $
��Left=�6"   $��775,173,0,0q�6=   $	��Top=�6R   �� 5   
   -   5        $ 	cboMoneda��5      $
��Left=�6&   $��832,173,0,0q�6A   $	��Top=�6V   $��62��6n   .@�5      �� $	��S/.��6   �� 5      $��$��6   5       �� 5!   
   -	   5         ��Name$ chkIgv��5!      $��Sin IGV��6#   $
��Left=�65   $��832,215,0,0q�6P   $	��Top=�6e   $ 
0.21,1.778&�6}   6�   &   System.Windows.Controls.DataGrid  5"   
   -
   5          Name$ 
dgvListado��5"      $��Right=�6(   $	��Top=�6F   $��0,299,104,0q�6_   $	��845��6t   $	��190��6�   ���	#FFB8B6B6	   AutoGenerateColumns	 .  
   CanUserAddRows
 .     SelectionMode$ Single=�5%         CanUserDeleteRows .    CanUserResizeRows .     CanUserSortColumns .     HeadersVisibility$ Column=�5)         GridLinesVisibility$
 None=�5*         SelectionUnit$ FullRow=�5+      ���	#FFA8A8A8$��1q�64      Columns 5,      0  *System.Windows.Controls.DataGridTextColumn  5-      -   5        ITEM��,  &System.Windows.Controls.DataGridColumn   Header$
 ITEM��5-   3      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *ITEM+ �� StringFormat$
 0{0}��6o     5.      -   5        CANTIDAD��$ CANTIDAD��5.   7    .   6I   �� *
CANTIDAD+   EditingElementStyle 5/      �� 50       �� 
TargetType" ��6    .�51      -   5        52      54        55      -   5        DESCRIPCION��$ CONCEPTO DE SERVICIO��55   :    .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 450 6�    6X   �� *SERVICIO.DESCRIPCION+6�     56      -   5        DIAS��$
 DIAS��56   3    .   6A   �� *DIAS+ 57      �� 58      " ��6    .�59      -   5        5:      5<        5=      -   5        
PRECIO��$ PRECIO UNITARIO��5=   5    .  6N   �� *PRECIO+6i     5>      -   5        IMPORTE��$ IMPORTE��5>   6    . $ * 6u    6G   �� *	IMPORTE+6u   5A      �� 5B   
   -   5        $ chkCambiarNroFact��5B      $��Cambiar Nro. Contra.��6.   $
��Left=�6M   $��
582,13,0,0q�6h   $	��Top=�6|   6�   �� 5C   
   $��	Servicio:��6   $
��Left=�6$   $��142,208,0,0q�6?   $	��Top=�6T   �� 5D   
   -   5        $ cboServicio��5D      $
��Left=�6(   $��227,208,0,0q�6C   $	��Top=�6X   $	��317��6p    �� 
IsEditable . 6�   �� 5E   
   $��	Cantidad:��6   $
��Left=�6$   $��554,208,0,0q�6?   $	��Top=�6T   �� 5F   
   -   5        $ txtCantidad��5F      $
��Left=�6'   $��23��6B   $��621,208,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $��45��6�   6�   �� 5G   
   -   5         ��Name$ btnAgregarDetalle��5G      $��Agregar Detalle��6,   $
��Left=�6F   $��752,250,0,0q�6a   $	��Top=�6v   $	��137��6�   
����������	#FF42A9FF$
��Bold"�6�   6�   �� 5H   
   $��Precio:��6   $
��Left=�6"   $��676,208,0,0q�6=   $	��Top=�6R   �� 5I   
   -   5        $ 	txtPrecio��5I      $
��Left=�6%   $��23��6@   $��732,208,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $��70��6�   ���	#FFB6B6B66�   �� 5J   
   -   5        $ txtSubtotal��5J      $
��Left=�6'   $��23��6B   $��778,497,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $��87��6�   {�.  $	��0.0��6�   $
��Bold"�6�   �� 5K   
   -   5        $ txtIgv��5K      $
��Left=�6"   $��23��6=   $��778,525,0,0q�6I   $
 Wrap=�6^   $	��Top=�6r   $��87��6�   {�.  $	��0.0��6�   $
��Bold"�6�   �� 5L   
   -   5        $ txtTotal��5L      $
��Left=�6$   $��23��6?   $��778,553,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $��87��6�   {�.  $	��0.0��6�   $
��Bold"�6�   �� 5M   
   $��
Sub Total:��6   $
��Left=�6%   $��712,496,0,0q�6@   $	��Top=�6U   $ 1.553,0.423&�6m   �� 5N   
   $
��IGV:��6   $
��Left=�6   $��735,524,0,0q�6:   $	��Top=�6O   $ 1.553,0.423&�6g   �� 5O   
   $��Total:��6   $
��Left=�6!   $��725,552,0,0q�6<   $	��Top=�6Q   $ 1.553,0.423&�6i   �� 5P   
   -   5        $ btnGenerarContrato��5P      $��Generar Contrato��6-   $
��Left=�6H   $��418,527,0,0q�6c   $	��Top=�6x   $	��157��6�   ���	#FF42A9FF
�������$
��Bold"�6�   $��45��6�   6�   �� 5Q   
   -   5        $ txtCancelar��5Q      $��Salir��6&   $
��Left=�66   $��584,527,0,0q�6Q   $	��Top=�6f   $	��103��6~   $��45��6�   ���	#FFF10E0E���	#FFAEAEAE
�������$
��Bold"�6�   6�   �� 5R   
   -   5        $ btnEliminarDetalle��5R      $��Eliminar��6-   $
��Left=�6@   $��672,250,0,0q�6[   $	��Top=�6p   $��75��6�   ���	#FFF10E0E���	#FFF9F3F3$
��Bold"�6�   6�   �� 5S   
   $��Telf.:��6   $
��Left=�6!   $��
745,68,0,0q�6<   $	��Top=�6P   �� 5T   
   -   5        $ txtTelf��5T      $
��Left=�6#   $��23��6>   $��
784,68,0,0q�6J   $
 Wrap=�6^   $��
��6r   $	��Top=�6�   $	��120��6�   �� 5U   
   -   5        $ txtTransporte��5U      $
��Left=�6)   $��23��6D   $��182,134,0,0q�6P   $
 Wrap=�6e   $	��Top=�6y   $	��256��6�   �� 5V   
   $��Transporte:��6   $
��Left=�6&   $��107,133,0,0q�6A   $	��Top=�6V   �� 5W   
   $��	Vendedor:��6   $
��Left=�6$   $��445,134,0,0q�6?   $	��Top=�6T   �� 5X   
   $��
Tipo Doc.:��6   $
��Left=�6%   $��734,133,0,0q�6@   $	��Top=�6U   �� 5Y   
   -    5        $ cboTipoDocumento��5Y      $
��Left=�6-   $��806,133,0,0q�6H   $	��Top=�6]   $��97��6u   .@�5Z      �� $��FACTURA��6   �� 5[      $��BOLETA��6   5\      &   Xceed.Wpf.Toolkit.DateTimePicker  5_   
   -!   5          Name$ txtFechaEntrega��5_      $
��Left=�68   $��182,175,0,0q�6S   $	��Top=�6h   $	��261��6�   $��26��6�   6�   �� 5`   
   $��F.E. :��6   $
��Left=�6!   $��140,175,0,0q�6<   $	��Top=�6Q     5a   
   -"   5        $ txtFechDevolucion��5a      $
��Left=�69   $��497,175,0,0q�6T   $	��Top=�6i   $	��261��6�   $��26��6�   {�.  6�   �� 5b   
   $��F.D. :��6   $
��Left=�6!   $��464,175,0,0q�6<   $	��Top=�6Q   �� 5c   
   -#   5        $ txtDias��5c      $
��Left=�6#   $��23��6>   $��
99,176,0,0q�6J   $
 Wrap=�6^   $��


��6r   $	��Top=�6�   $��36��6�   $ 1.306,0.115&�6�   {�.  6�   �� 5d   
   $��Total días:��6   $
��Left=�6&   $��
33,176,0,0q�6A   $	��Top=�6U   �� 5e   
   $��Garantia S/.
��6   $
��Left=�61   $��
30,498,0,0q�6L   $	��Top=�6`   $��28��6x   �� 5f   
   -$   5        $ txtGarantia��5f      $
��Left=�6'   $��23��6B   $��102,499,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $��76��6�   �� 5g   
   $��Cheque:
��6   $
��Left=�6'   $��190,500,0,0q�6B   $	��Top=�6W   $��28��6o   �� 5h   
   -%   5        $ 	txtCheque��5h      $
��Left=�6%   $��23��6@   $��242,501,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��156��6�   �� 5i   
   $��Documento:
��6   $
��Left=�6*   $��
30,530,0,0q�6E   $	��Top=�6Y   $��28��6q   �� 5j   
   -&   5        $ txtDocumento��5j      $
��Left=�6(   $��23��6C   $��102,531,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��296��6�   �� 5k   
   $��Recibo:
��6   $
��Left=�6'   $��
30,560,0,0q�6B   $	��Top=�6V   $��28��6n   �� 5l   
   -'   5        $ 	txtRecibo��5l      $
��Left=�6%   $��23��6@   $��102,561,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��296��6�   	� 5m   
   -(   5         	�Name$ 	rbNATURAL��5m      $��NATURAL��6)   $
��Left=�6;   $��
232,41,0,0q�6V   $	��Top=�6j   6�   	� 5n   
   -)   5        $ 
rbJURIDICA��5n      $��JURIDICA��6*   $
��Left=�6=   $��
344,41,0,0q�6X   $	��Top=�6l   6�   �� 5o   
   $��Tipo Cliente:��6   $
��Left=�6(   $��
147,37,0,0q�6C   $	��Top=�6W   $ 0.531,-0.346&�6o   �� 5p   
   -*   5        $ cboVendedor��5p      $
��Left=�6(   $��515,135,0,0q�6C   $	��Top=�6X   $	��219��6p   �� 5q   
   -+   5        $ btnCambiarFactura��5q      $��Factura��6,   $
��Left=�6>   $��878,358,0,0q�6Y   $	��Top=�6n   $��75��6�   ���	#FF13BD68
�������$
��Bold"�6�   $ 0.707,-0.586&�6�   �� 5r   
   $��
Cambiar a:��6   $
��Left=�6%   $��881,330,0,0q�6@   $	��Top=�6U   �� 5s   
   -,   5        $ btnCambiarBoleta��5s      $��Boleta��6+   $
��Left=�6<   $��876,392,0,0q�6W   $	��Top=�6l   $��81��6�   ���	#FF13BD68
�������$
��Bold"�6�   $ 0.707,-0.586&�6�   6�   �� 5t   
   --   5        $ btnCambiarGuia��5t      $��Guía��6)   $
��Left=�68   $��876,426,0,0q�6S   $	��Top=�6h   $��81��6�   ���	#FF13BD68
�������$
��Bold"�6�   $ 0.707,-0.586&�6�   6�   5w      5x      