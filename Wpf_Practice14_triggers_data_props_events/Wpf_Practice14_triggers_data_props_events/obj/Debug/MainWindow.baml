   M S B A M L   `   `   `  ����d  `Wpf_Practice14_triggers_data_props_events, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:Wpf_Practice14_triggers_data_props_events)Wpf_Practice14_triggers_data_props_events  5   	   :    4Wpf_Practice14_triggers_data_props_events.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Ilocal7clr-namespace:Wpf_Practice14_triggers_data_props_events     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      �� $��10q�6   .+�5
   
   � .+�5      �� $��32(�6   $��Center=�6&   $��Center=�6C   hello earth��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 � d �6K    �� Triggers 5      P� 5       P� Property �@J�IsMouseOver P� Value . . �5   "   ��  � ��
 �� ��6T   �� 5   "    � ��$ Italic$�6>   6O   �� 5   "    � ��$ 	ExtraBold"�6?   6S   5      5      5      5      � 5   
   .+�5      �� $��16(�6   $��Center=�6&   $��Center=�6C   hey buddy, how's it going?��5      �� 5      " ��6    5      :� 5        :� RoutedEvent$ 
MouseEnter��6+   [�5!   "   �� 5"   &   .��5#   *   �� .��5%   .   W�  g� Duration$ 0:0:1.5D�6>   	 �� TargetProperty$	 FontSize�6Q   	
 W� To$
 66X�6v   6�   5&   +   5'   '   5)      :� 5*      $ 
MouseLeave��6+   [�5+   "   �� 5,   &   .��5-   *   �� .��5.   .   W� $ 0:0:1D�6>   $	 FontSize�6O   $
 16X�6t   6~   5/   +   50   '   52      54      56      57      �� 58   
   $��Center=�6   $��Center=�62   .+�59      �� -   5        $��cbHello��59      .��6&   is anyone home?67   �� 5:      $��Center=�6   $��36(�65   ��5;      �� 5<      " ��6   .�5=      ��  � ��$ No��61   6>   �� 5>       � ��
 �  ��6I    5?      �� 5B       �� Binding 6*   ��  �� ElementName$ cbHello�� �� Path$ 	IsChecked� �� Value True6b   .a�5C   "   ��  � ��$3 -Hello...my friend...do you see me anymore....��69   6q   �� 5D   "    � ��
 �� ��6T   5E      5G      5I      5J      5K      5L      