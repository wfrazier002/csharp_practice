   M S B A M L   `   `   `  ����R  NWpf_Practice_ZooManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Wpf_Practice_ZooManagerWpf_Practice_ZooManager  5   	   (    "Wpf_Practice_ZooManager.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:Wpf_Practice_ZooManager     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��800��6)   .��5	      � .+�5
   
   �� $��Zoo List��6   $
��Left=�6#   $��	56,10,0,0q�6>   $	��Top=�6Q   �� 5   
   -   5        $��ListZoos��5      $
��Left=�6"   $	��244��6=   $��	10,41,0,0q�6J   $	��Top=�6]   $	��140��6u   6�   �� 5   
   $$��Animals in a Specific Zoo List��6   $
��Left=�69   $��
305,10,0,0q�6T   $	��Top=�6h   �� 5   
   -   5        $��ListZooAnimals��5      $
��Left=�6(   $	��245��6C   $��
305,41,0,0q�6P   $	��Top=�6d   $	��163��6|   �� 5   
   $��Animal List��6   $
��Left=�6&   $��
667,10,0,0q�6A   $	��Top=�6U   �� 5   
   -   5        $��ListAnimals��5      $
��Left=�6%   $	��244��6@   $��
630,41,0,0q�6M   $	��Top=�6a   $	��140��6y   6�   �� 5   
   -   5        $��Add Animal to Zoo��5      $
��Left=�6-   $��336,305,0,0q�6H   $	��Top=�6]   $	��112��6u   6�   �� 5   
   -   5        $��Remove Animal From Zoo��5      $
��Left=�62   $��311,335,0,0q�6M   $	��Top=�6b   $	��153��6z    J� RenderTransformOrigin$ 0.606,0.468&�6�   6�   �� 5   
   -   5        $��
Delete Zoo��5      $
��Left=�6&   $��
33,304,0,0q�6A   $	��Top=�6U   $��97��6m   $ 0.556,-0.726&�6x   6�   �� 5   
   -   5        $��Add Zoo��5      $
��Left=�6#   $��
33,402,0,0q�6>   $	��Top=�6R   $��97��6j   $ 0.556,-0.726&�6u   6�   �� 5   
   -   5        $��
Update Zoo��5      $
��Left=�6&   $��
32,435,0,0q�6A   $	��Top=�6U   $��97��6m   $ 0.556,-0.726&�6x   6�   �� 5   
   -	   5        $��Delete Animal��5      $
��Left=�6)   $��651,303,0,0q�6D   $	��Top=�6Y   $��97��6q   $ 0.556,-0.726&�6|   6�   �� 5   
   -
   5        $��
Add Animal��5      $
��Left=�6&   $��651,402,0,0q�6A   $	��Top=�6V   $��97��6n   $ 0.556,-0.726&�6y   6�   �� 5   
   -   5        $��Update Animal��5      $
��Left=�6)   $��651,437,0,0q�6D   $	��Top=�6Y   $��97��6q   $ 0.556,-0.726&�6|   6�   �� 5   
   -   5        $��inputtxtBox��5      $
��Left=�6%   $��50��6@   $��158,404,0,0q�6L    �� TextWrapping$
 Wrap=�6a   $��TextBox��6u   $	��Top=�6�   $	��464��6�   �� 5   
   $U��OTextbox to add animal to animal list, zoo to zoo list, or update existing items��6   $
��Left=�6j   $��176,372,0,0q�6�   $	��Top=�6�   $	��443��6�   $��25��6�   5      5      