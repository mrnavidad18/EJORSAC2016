   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC'   !SISJORSAC.FrmListadoGuiasRemision   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	     � Title$#  Listado de Guias de Remisión��5   	   $��660.001��6.   $��1222.247��6?    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.   .��5
      � .+�5   
   �� -   5         ��Name$ lblBusqueda��5      $0��*Buscar por Número de Guía/Tipo Traslado:��6%   $
��Left=�6X   $��695,105,0,0q�6s   $	��Top=�6�   $	��248��6�   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgvListadoGuia��5      $
��Left=�6-   $��
49,153,0,0q�6H   $	��Top=�6\   $	��401��6t   $
��1137��6�      AutoGenerateColumns .     GridLinesVisibility$	 All=�6�   $��1q�6�   �� 5   
   -   5         ��Name$ txtBusqueda��5      $
��Left=�6'   $��23��6B   $��948,105,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��225��6�   6�   �� 5   
   $
��Left=�6   $��
49,0,0,501q�6+   $	��125��6?   $	��121��6K   $��Bottom=�6X   $
��Fill=�6s   $��IMG/logo_rep.PNG��6�   �� 5   
   $"��Listado de Guia de Remisión��6   $
��Left=�66   $��
490,32,0,0q�6Q   $	��Top=�6e   $
��Bold"�6}   $��37��6�   $	��305��6�   $��22(�6�   ��6�   Z� 6�   �� 5   
   -   5        	 ��Name$	 btnVerDetalle��5      $��Ver Detalle��6(   $
��Left=�6>   $��553,573,0,0q�6Y   $	��Top=�6n   $	��103��6�   ���	#FF39A3D4$
��Bold"�6�   
�������6�   5      5      