   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC'   !SISJORSAC.FrmListadoConceptoGasto   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   
   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	     � Title$"  Listado de Concepto de Gasto��5   	   $��479.045��6.   $��1040.337��6?    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.   .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgvListadoConceptoGasto��5      $
��Left=�66   $��
28,150,0,0q�6Q   $	��Top=�6e   $	��272��6}   $	��970��6�      AutoGenerateColumns .     GridLinesVisibility$	 All=�6�   $��1q�6�   6�   �� 5   
   $
��Left=�6   $��
28,0,0,317q�6+   $	��125��6?   $	��121��6K   $��Bottom=�6X   $
��Fill=�6s   $��IMG/logo_rep.PNG��6�   �� 5   
   $��Listado Concepto de Gasto��6   $
��Left=�64   $��
348,24,0,0q�6O   $	��Top=�6c   $
��Bold"�6{   $��37��6�   $	��296��6�   $��22(�6�   ��6�   Z� 6�   �� 5   
   $��Buscar por descripción:��6   $
��Left=�62   $��599,109,0,0q�6M   $	��Top=�6b   $
��Bold"�6z   �� 5   
   -   5         ��Name$ txtBusqueda��5      $
��Left=�6'   $��23��6B   $��754,109,0,0q�6N    �� TextWrapping$
 Wrap=�6c   $�� ��6w   $	��Top=�6   $	��235��6�   $
��Bold"�6�   6�   5      5      