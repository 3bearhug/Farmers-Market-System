   M S B A M L   `   `   `  ����D  @FamersWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:FamersWPF	FamersWPF  5   	       FamersWPF.Admin   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:FamersWPF     5   	     � Title$  FarmersWPF Application��5   	   $	��450��6(   $	��800��65   .��5	      � ��5
   
   �� 5       �� ImageSource$% Resource/wordpress-rest-api.jpg��6   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ showallgrid��5      $��23,279,28,10q�6)   �� 5   
   -   5         ��Name$ label1��5      $��Product Name ��6    $
��Left=�68   $��
117,67,0,0q�6S   $	��Top=�6g   $��16(�6   ���	#FF94EFFB$��Georgia)�6�   �� 5   
   -   5         ��Name$ namebox��5      $
��Left=�6#   $��
253,67,0,0q�6>    �� TextWrapping$
 Wrap=�6R   $	��Top=�6f   $	��120��6~   $��31��6�   $��16(�6�   �� 5   
   -   5        $ label2��5      $��
Product ID��6    $
��Left=�65   $��117,123,0,0q�6P   $	��Top=�6e   $��16(�6}   ���	#FF94EFFB$��Georgia)�6�   �� 5   
   -   5        $ idbox��5      $
��Left=�6!   $��253,123,0,0q�6<   $
 Wrap=�6Q   $	��Top=�6e   $	��120��6}   $��31��6�   $��16(�6�   �� 5   
   -   5        $ label3��5      $��Amount (KG)��6    $
��Left=�66   $��117,169,0,0q�6Q   $	��Top=�6f   $��16(�6~   ���	#FF94EFFB$��Georgia)�6�   �� 5   
   -   5        $ 	amountbox��5      $
��Left=�6%   $��253,169,0,0q�6@   $
 Wrap=�6U   $	��Top=�6i   $	��120��6�   $��31��6�   $��16(�6�   �� 5   
   -   5        $ label4��5      $��Price Per KG��6    $
��Left=�67   $��117,217,0,0q�6R   $	��Top=�6g   $��16(�6   ���	#FF94EFFB$��Georgia)�6�   �� 5   
   -	   5        $ pricebox��5      $
��Left=�6$   $��253,217,0,0q�6?   $
 Wrap=�6T   $	��Top=�6h   $	��120��6�   $��31��6�   $��16(�6�   �� 5   
   -
   5        $ title��5      $;��5Products Database Connection with REST API Properties��6   $��Center=�6_   $��0,10,0,0q�6|   $	��Top=�6�   $	��408��6�   $��16(�6�   $��36��6�   ���	#FFC3C6FD$��Georgia)�6�   �� 5   
   -   5         ��Name$ 	addbutton��5      $��Add Product��6$   $
��Left=�6:   $��429,123,0,0q�6U   $	��Top=�6j   $��51��6�   $	��128��6�   $��16(�6�   ���	#FFF9F7BC$��Georgia)�6�   6�   �� 5   
   -   5        $ showallbutton��5      $��List All Products��6(   $
��Left=�6D   $��594,123,0,0q�6_   $	��Top=�6t   $��51��6�   $	��133��6�   $��16(�6�   ���	#FFF9F7BC$��Georgia)�6�   6�   �� 5   
   -   5        $ updatebutton��5      $��Update Product��6'   $
��Left=�6@   $��429,200,0,0q�6[   $	��Top=�6p   $��48��6�   $	��128��6�   $��16(�6�   ���	#FFF9F7BC$��Georgia)�6�   6�   �� 5   
   -   5        $ searchbutton��5      $��Search��6'   $
��Left=�68   $��
615,67,0,0q�6S   $	��Top=�6g   $��65��6   $��31��6�   $��16(�6�   ���	#FFF9F7BC$��Georgia)�6�   6�   �� 5   
   -   5        $ label55��5      $
��Left=�6#   $��
452,67,0,0q�6>   $
 Wrap=�6R   $��Search with ID��6f   $	��Top=�6|   $	��120��6�   $��16(�6�   $��Georgia)�6�   �� 5   
   -   5        $ deletebutton��5      $��Delete Products��6'   $
��Left=�6A   $��594,200,0,0q�6\   $	��Top=�6q   $��48��6�   $	��133��6�   $��16(�6�   ���	#FFF9F7BC$��Georgia)�6�   6�   �� 5   
   -   5        $ clearbutton��5      $��Clear��6&   $
��Left=�66   $��
713,67,0,0q�6Q   $	��Top=�6e   $��32��6}   $��16(�6�   $��59��6�   ���	#FFF4B2FF$��Georgia)�6�   6�   �� 5   
   -   5        $ responselabel��5      $��Server Response Message��6'   $
��Left=�6I   $��429,253,0,0q�6d   $	��Top=�6y   $	��343��6�   $��14(�6�   ���	#FF080808���	#FFF90505$
��Bold"�6�   �� 5   
   -   5        $ salesbutton��5      $��Sales��6&   $
��Left=�66   $��	23,10,0,0q�6Q   $	��Top=�6d   $��Georgia)�6|   $��16(�6�   
���   ����	#FF58F5696�   5"      5#      