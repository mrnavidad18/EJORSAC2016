   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=1.2.4.0, Culture=neutral, PublicKeyToken=f4fb5a3c4d1e5b4fZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours  5   	   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	    	SISJORSAC   SISJORSAC.FrmElegirBoleta   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   	   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5   	     � Title$  Elegir Boleta��5   	   $��165.957��6   $	��300��60    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�6.   .��5
      �  � ColumnDefinitions 5   
   �� 5      .+�5   
   	� -   5         	�Name$ 
rbtSinGuia��5      $��Sin Guia��6*   $
��Left=�6=   $��	45,34,0,0q�6X   $	��Top=�6k   6�   	� 5   
   -   5        $ 
rbtConGuia��5      $��	Con  Guia��6*   $
��Left=�6>   $��
161,34,0,0q�6Y   $	��Top=�6m   6�   �� 5   
   -   5         ��Name$ 
txtnroGuia��5      $
��Left=�6&   $��23��6A   $��	85,72,0,0q�6M    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��120��6�   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese Nro. Guía��6�   $y�Hidden=�6�   �� 5   
   -   5        $��btnIngresar��5   �   $��Ingresar��6   $
��Left=�6$   $��	85,98,0,0q�6?   $	��Top=�6R   $	��120��6j   $y�Hidden=�6v   6�   5      5      