   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC"   SISJORSAC.FrmListadoClientes   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	     � Title$  Listado de Clientes��5   	   $��627.045��6%   $��1207.337��66    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.   .��5
      � .+�5   
   �� -   5         ��Name$ lblBusqueda��5      $�� ��6%   $
��Left=�60   $��
379,89,0,0q�6K   $	��Top=�6_   $	��239��6w   $
��Bold"�6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgvListadoCliente��5      $
��Left=�60   $��
28,131,0,0q�6K   $	��Top=�6_   $	��438��6w   $
��1145��6�      AutoGenerateColumns .     GridLinesVisibility$	 All=�6�   $��1q�6�   6�   �� 5   
   $$��Seleccione el tipo de Cliente:��6   $
��Left=�6;   $��
897,59,0,0q�6V   $	��Top=�6j   $��58��6�   $	��275��6�   ���	#CC14568D6�   	� 5   
   -   5         	�Name$ 
rdbNatural��5      $��	NATURALES��6*   $
��Left=�6>   $��
919,89,0,0q�6Y   $	��Top=�6m   $
��Bold"�6�   	� 5   
   -   5        $ rdbJuridica��5      $��	JURIDICOS��6+   $
��Left=�6?   $��1054,89,0,0q�6Z   $	��Top=�6o    J� RenderTransformOrigin$ 0.5,0.5&�6�   $
��Bold"�6�   �� 5   
   -   5        	 ��Name$	 txtBusqueda��5      $
��Left=�6'   $��23��6B   $��
627,89,0,0q�6N   
 �� TextWrapping$

 Wrap=�6b   $�� ��6v   $	��Top=�6~   $	��225��6�   $
��Bold"�6�   �� 5   
   $
��Left=�6   $��
28,0,0,470q�6+   $	��125��6?   $	��121��6K   $��Bottom=�6X   $
��Fill=�6s   $��IMG/logo_rep.PNG��6�   �� 5   
   $��Listado de Clientes:��6   $
��Left=�6/   $��
451,10,0,0q�6J   $	��Top=�6^   $
��Bold"�6v   $��37��6�   $	��272��6�   $��22(�6�   ��6�   Z� 6�   5      5      