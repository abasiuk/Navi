   M S B A M L   `   `   `  ����?  ;Navi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Navi.View	Navi.View  5          Navi.View.AddClientView   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Navi.View     5      .��5	      �   � RowDefinitions  5
   
   �� 5      �� 5      $��50 �6   .+�5   
   �� $��0��6   $��Center=�6"   $��Center=�6=   $	��300��6Z   .+�5   
   �� $��Прізвище��6   $��18(�6$   $��Center=�62   ���	#FFF9DF6A6O   �� 5   
   $	��200��6b    �� TextWrapping$
 Wrap=�6n   $��Center=�6�   $��18(�6�   $��0,0,0,2q�6�   ��6   �� *LastNameText+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5   
   $��Ім'я��6   $��18(�6    $��Center=�6.   ���	#FFF9DF6A6K   �� 5   
   $	��200��6c   $
 Wrap=�6o   $��Center=�6�   $��18(�6�   $��0,0,0,2q�6�   ��6   �� *FirstNameText+$ PropertyChanged=�$ TwoWay=�6�   �� 5   
   $��Email��6   $��18(�6!   $��Center=�6/   ���	#FFF9DF6A6L   �� 5   
   $	��200��6_   $
 Wrap=�6k   $��Center=�6   $��18(�6�   $��0,0,0,2q�6�   ��6   �� *	EmailText+$ PropertyChanged=�$ TwoWay=�6�   �� 5   
   $#��Дата народження��6   $��18(�6+   $��Center=�69   ���	#FFF9DF6A6V   (  "System.Windows.Controls.DatePicker  5   
   $	��200��6f   $��Center=�6r   $��18(�6�   $��0,0,0,2q�6�      Text 6   �� *DateBornText+$ PropertyChanged=�$ TwoWay=�6�   �� 5   
   $!��Вид абонементу��6   $��18(�6*   $��Center=�68   ���	#FFF9DF6A6U   �� 5   
   $	��200��6f   $
 Wrap=�6r   $��Center=�6�   $��18(�6�   $��0,0,0,2q�6�   ��6   �� *SubscriptionText+$ PropertyChanged=�$ TwoWay=�6�   �� 5         
MainButton#��[  6B   $��Добавити��6f   $	��200��6y   ��6   �� *
AddCommand+$ OneTime=�6y   5      �� 5      $��1��6    �� Orientation$ 
Horizontal=�6   $��Right=�67   $��0,10,0,0q�6S   .+�5      �� $��
Назад��6K   $	��100��6[   ��6   �� *BackToClientCommand+$ OneTime=�6[   5      5      5       