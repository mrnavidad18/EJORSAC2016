   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC   SISJORSAC.FrmGasto   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	     � Title$  Rsgistro - Egresos��5   	   $��661.425��6$   $��812.276��65    � 
ResizeMode$ NoResize=�6E    � WindowStartupLocation$ CenterScreen=�5   	   .��5	      � $��0,-1,0,1q�6   .+�5
   
   �� $
��Left=�6   $	��136��6+   $��	31,20,0,0q�68   $	��Top=�6K   $	��163��6c   $��IMG/logo_rep.PNG��6o   �� 5   
   $��Tipo Compro.:��6   $
��Left=�6(   $��
215,26,0,0q�6C   $	��Top=�6W   �� 5   
   $
��Left=�6   $��23��6-   $��
308,29,0,0q�69    �� TextWrapping$
 Wrap=�6M   $��EGRESO��6a   $	��Top=�6o   $��57��6�   {�.  $
��Bold"�6�   �� 5   
   $��Nro. Gasto:��6   $
��Left=�6&   $��
381,28,0,0q�6A   $	��Top=�6U    J� RenderTransformOrigin$ 0.903,0.444&�6m   �� 5   
   -   5         ��Name$ txtNroGasto��5      $
��Left=�6'   $��23��6B   $��
453,28,0,0q�6N   $
 Wrap=�6b   $	��Top=�6v   $��70��6�    �� 	MaxLength$ 6��6�   {�.  ���	#FFCDCDCD6�   �� 5   
   $��Fech. Emisión:��6   $
��Left=�6)   $��
533,26,0,0q�6D   $	��Top=�6X   $ -0.352,-0.381&�6p   �� 5   
   -   5        $ txtFechaEmision��5      $
��Left=�6+   $��23��6F   $��
616,26,0,0q�6R   $
 Wrap=�6f   $	��Top=�6z   $��97��6�   �� 5   
   $��
Proveedor:��6   $
��Left=�6%   $��
428,64,0,0q�6@   $	��Top=�6T   $ 0.582,0&�6l   �� 5   
   -   5         ��Name$ cboProveedor��5      $
��Left=�6)   $��
428,92,0,0q�6D   $	��Top=�6X   $	��285��6p   $ 	0.125,0.5&�6|    �� 
IsEditable . {�.  6�   �� 5   
   $��Nro. Doc. Ref.��6   $
��Left=�6)   $��471,131,0,0q�6D   $	��Top=�6Y   $��97��6q   �� 5   
   -   5        $ txtNroDocRef��5      $
��Left=�6(   $��23��6C   $��568,130,0,0q�6O   $
 Wrap=�6d   $	��Top=�6x   $	��145��6�   {�. 6�   �� 5   
   -   5        	 ��Name$	 btnAgregarDetalle��5      $��Agregar Detalle��6,   $
��Left=�6F   $��658,218,0,0q�6a   $	��Top=�6v   $	��136��6�   ���	#FF3D97F1
�������$
��Bold"�6�   6�   �� 5   
   -   5        $	 btnEliminar��5      $��Eliminar��6&   $
��Left=�69   $��572,218,0,0q�6T   $	��Top=�6i   $��81��6�   ���	#FFEE0B00
�������$ 
-0.4,0.586&�6�   $
��Bold"�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        
  Name$
 
dgvListado��5      $��Right=�6(   $	��Top=�6F   $��
0,281,17,0q�6_   $	��782��6s   $	��257��6   ���	#FFB8B6B6   AutoGenerateColumns .     CanUserAddRows .     SelectionMode$ Single=�5         CanUserDeleteRows .    CanUserResizeRows .     CanUserSortColumns .     HeadersVisibility$ Column=�5         GridLinesVisibility$
 None=�5          SelectionUnit$ FullRow=�5!      ���	#FFA8A8A8$��1q�67      Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      -   5        ITEM��,  &System.Windows.Controls.DataGridColumn   Header$
 ITEM��5#   3      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� *ITEM+ �� StringFormat$
 0{0}��6o     5$      -	   5        CANTIDAD��$ CANTIDAD��5$   7    .   6I   �� *
CANTIDAD+   EditingElementStyle 5%      �� 5&       �� 
TargetType" ��6    .�5'      -
   5        5(      5*        5+      -   5        DESCRIPCION��$' !DESCRIPCION: CONCEPTO DE SERVICIO��5+   :    .    Width5  /System.Windows.Controls.DataGridLengthConverter$	 450 6�    6e   �� *ConceptoGasto.DESCRIPCION+6�     5,      -   5        
PRECIO��$ PRECIO UNITARIO��5,   5    .  6N   �� *PRECIO+6i     5-      -   5        IMPORTE��$ IMPORTE��5-   6    . $ * 6u    6G   �� *	IMPORTE+6u   50      �� 51   
   -   5        $ txtTotal��51      $
��Left=�6$   $��23��6?   $��695,545,0,60q�6K   $
 Wrap=�6a   $��87��6u   {�.  $	��0.0��6�   $
��Bold"�6�   �� 52   
   $��Total:��6   $
��Left=�6!   $��643,543,0,0q�6<   $	��Top=�6Q   $ 1.553,0.423&�6i   �� 53   
   -   5        $	 btnGenerarGasto��53      $��Generar Gasto��6*   $
��Left=�6B   $��565,582,0,0q�6]   $	��Top=�6r   $	��137��6�   ���	#FF42A5F7
�������$
��Bold"�6�   $��35��6�   6�   �� 54   
   -   5        $	 btnCancelar��54      $��Salir��6&   $
��Left=�66   $��716,582,0,0q�6Q   $	��Top=�6f   $��64��6~   $��35��6�   ���	#FFE24030���	#FFAEAEAE
�������$
��Bold"�6�   6�   �� 55   
   -   5         ��Name$ chkObservacion��55      $��Ingresar observaciones��6+   $
��Left=�6L   $��44,544,0,-292q�6g   $	��Top=�6~   6�   �� 56   
   -   5        $ txtObservacion��56      $
��Left=�6*   $��58��6E   $��44,563,-58,-351q�6Q   $
 Wrap=�6j   $	��Top=�6~   $	��306��6�   {�.  6�   �� 57   
   $��	Servicio:��6   $
��Left=�6$   $��215,174,0,0q�6?   $	��Top=�6T   �� 58   
   -   5        $ cboServicio��58      $
��Left=�6(   $��269,171,0,0q�6C   $	��Top=�6X   $	��299��6p   {�.  . 6�   �� 59   
   $��Precio:��6   $
��Left=�6"   $��576,170,0,0q�6=   $	��Top=�6R   �� 5:   
   -   5        $ 	txtPrecio��5:      $
��Left=�6%   $��23��6@   $��626,170,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $��87��6�   ���	#FFB6B6B66�   �� 5;   
   $��	Doc. Ref.��6   $
��Left=�6$   $��213,131,0,0q�6?   $	��Top=�6T   $ 0.582,0&�6l   �� 5<   
   -   5        $ 	txtDocRef��5<      $
��Left=�6%   $��23��6@   $��292,130,0,0q�6L   $
 Wrap=�6a   $	��Top=�6u   $	��161��6�   ���	#FFB6B6B66�   �� 5=   
   $��Tipo de Proveedor��6   $
��Left=�6.   $��
216,58,0,0q�6I   $	��Top=�6]   $	��197��6u   $��60��6�   	� 5>   
   -   5         	�Name$ 	rdNATUTAL��5>      $��NATURAL��6)   $
��Left=�6;   $��
240,93,0,0q�6V   $	��Top=�6j   6�   	� 5?   
   -   5        $ 
rbJURIDICA��5?      $��JURIDICA��6*   $
��Left=�6=   $��
321,93,0,0q�6X   $	��Top=�6l   6�   �� 5@   
   $��	Cantidad:��6   $
��Left=�6$   $��209,200,0,0q�6?   $	��Top=�6T   �� 5A   
   -   5        $ txtCantidad��5A      $
��Left=�6'   $��23��6B   $��269,202,0,0q�6N   $
 Wrap=�6c   $	��Top=�6w   $��45��6�   $ 5��6�   6�   5C      5D      