   M S B A M L   `   `   `  ����E  AClasesBase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;,clr-namespace:ClasesBase;assembly=ClasesBase
ClasesBase  5   	   
 Vistas   Vistas.SectoresOcupados   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   <svc,clr-namespace:ClasesBase;assembly=ClasesBase     5   	     � Icon$(  "/Vistas;component/Images/Logo1.PNG��5   @      MyWindowDefault#��[  6j    � Title$ Sectores Ocupados��5   	   $	��606��6#   $	��976��60    � WindowStartupLocation$ CenterScreen=�6=   ���	#FF003053.��5      �  � RowDefinitions 5   
   �� 5      $	��70* �6   �� 5	      $
��576* �6   �� 5
      $	��70* �6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dgSecOcupados��5      $��16,25,16,25q�6*      AutoGenerateColumns .    CanUserAddRows .     
IsReadOnly . $��1��6�   $��
Constantia)�6�   $��18(�6�   $
��Bold"�6�   ���	#FF7ED8CE���	#FF003053$��Center=�61  $��Center=�6w  ��6�   Z�    HorizontalGridLinesBrush 6  Z� 	   VerticalGridLinesBrush	 6U  Z� 
   ColumnHeaderStyle
 5      �� 5       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5      ��  �� Property � �� �� Value 5      �� 5       �� 
TargetType"  6.   .R�5   "   �� $��2,2,2,2q�6)   ���	#FF124D93���	#FF007E81._�5   &   ��  ��Name$ ContentHeader��60   #��z��6G    �� Padding$ 5,5,5,5q�6h    �� TextAlignment$ Center=�6z   5   #   5      5      �� 5       �@�OverridesDefaultStyle .  6>   �� 5       � �� �	#FF46E5CE63   �� 5       � ��$ 
Constantia)�63   5         	CellStyle 5      �� 5       *  $System.Windows.Controls.DataGridCell"  6   .�5!      ��  � ��$ Center=�6<   5"         RowStyle 5&      �� 5'      )  #System.Windows.Controls.DataGridRow"  6   .�5(      ��  � �� �	#FF7ED8CE63   5)      5,      �� 5.   
   -   5        $��	lblTitulo��5.   r   $��Sectores Ocupados��6   $��Center=�6,   $��Center=�6G   $��20(�6d   $��
Constantia)�6�   $
��Bold"�6�   ���	#FF7ED8CE$
��Auto��6�   �� 5/   
   -   5        $��Imprimir Listado��5/      $��Center=�6M   $��Center=�6h     	btnEstilo#��[ 6�   $	��300��6�   $��2��6�   $��40��6�   $
��Bold"�6�   ���	#FF003053���	#FF7ED8CE��6�   Z� 6  50      51      