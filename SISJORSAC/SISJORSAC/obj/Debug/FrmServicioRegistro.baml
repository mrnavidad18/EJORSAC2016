   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC#   SISJORSAC.FrmServicioRegistro   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	     � Title$  Registro - Servicios��5   	   $��380.1��6&   $	��637��65    � WindowStartupLocation$ CenterScreen=�5   	   (   "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush �	#FF633333 � 
ResizeMode$ NoResize=�6K   .��5
      � -   5        $��	Servicios��5
      $��0,0,-8,0q�6    � ColumnDefinitions 5   
   �� 5      �� 5      $
��Auto �6   .+�5   
   �� $��Descripción:��6   $
��Left=�6'   $��
130,25,0,0q�6B   $	��Top=�6V   $��26��6n   $��74��6z   �� 5   
   $��
Precio S/.��6   $
��Left=�6%   $��
133,81,0,0q�6@   $	��Top=�6T   $��26��6l   $��60��6x   �� 5   
   $��Peso:��6   $
��Left=�6    $��133,110,0,0q�6;   $	��Top=�6P   $��26��6h   $��35��6t   �� 5   
   -   5         ��Name$ txtDescripcion��5      $
��Left=�6*   $��51��6E   $��
250,25,0,0q�6Q    �� TextWrapping$
 Wrap=�6e   $�� ��6y   $	��Top=�6�   $	��301��6�   �� 5   
   -   5        $ 	txtPrecio��5      $
��Left=�6%   $��26��6@   $��
250,81,0,0q�6L   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $��73��6�   6�   �� 5   
   -   5        $ txtPeso��5      $
��Left=�6#   $��26��6>   $��250,114,0,0q�6J   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $��73��6�   6�   �� 5   
   -   5         ��Name$ btnServicio��5      $��Agregar Servicio��6&   $
��Left=�6A   $��133,229,0,0q�6\   $	��Top=�6q   $	��145��6�   $��29��6�   ���	#FF76A5DE$
��Bold"�6�   ���	#FFF3F3F36�   �� 5   
   -   5        $ btnLimpiarTodo��5      $��Limpiar Todo��6)   $
��Left=�6@   $��304,229,0,0q�6[   $	��Top=�6p   $	��140��6�   ���	#FFD43434
�������$
��Bold"�6�   6�   �� 5   
   $
��Left=�6   $��	0,0,0,212q�6+   $	��125��6>   $	��121��6J   $��Bottom=�6W   $
��Fill=�6r   $��IMG/logo_rep.PNG��6�   �� 5   
   $��Stock:��6   $
��Left=�6!   $��133,149,0,0q�6<   $	��Top=�6Q   $��26��6i   $��60��6u   �� 5   
   $��Unidad de Medida:��6   $
��Left=�6,   $��133,178,0,0q�6G   $	��Top=�6\   $��26��6t   $	��112��6�   �� 5   
   -   5        $ txtStock��5      $
��Left=�6$   $��26��6?   $��250,149,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $��73��6�   6�   �� 5   
   -   5        $ txtUnidadMedida��5      $
��Left=�6+   $��26��6F   $��250,182,0,0q�6R   $
 Wrap=�6g   $�� ��6{   $	��Top=�6�   $��73��6�   6�   5      5      