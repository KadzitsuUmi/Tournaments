   M S B A M L   `   `   `  ����I  ETournamentsWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:TournamentsWPFTournamentsWPF  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089I2clr-namespace:System.Collections;assembly=mscorlibSystem.Collections 5   	       TournamentsWPF.InfoWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:TournamentsWPF     5   	   Bcol2clr-namespace:System.Collections;assembly=mscorlib     5   	     � Title$  
Отчет��5	   	   $��538.653��6   $��538.41��6(   ���	#FFE0E8F5 � 
ResizeMode$ NoResize=�6N   .��5
      � $��0,0,2,-4q�6    � ColumnDefinitions 5   
   �� 5      $	��55* �6   �� 5      $
��391* �6   .+�5   
   �� $
��Left=�6   $��	27,25,0,0q�6/   $
��Wrap=�6B   $5��/Введите название турнира:��6V   $	��Top=�6w   $��2��6�   $��16(�6�   �� 5   
   -   5         ��Name$ TournamentName��5      $
��Left=�6*   $��23��6E   $��
176,25,0,0q�6Q    �� TextWrapping$
 Wrap=�6e   $	��Top=�6z   $	��120��6�   $��1��6�   �� 5   
   -   5         ��Name$ CreateTournamentButton��5      $��Загрузить��61   $
��Left=�6E   $��
313,19,0,0q�6`   $	��Top=�6t   $	��105��6�   $��34��6�   $��1��6�   $��16(�6�   � 5   
   $
��Left=�6   $	��398��6*   $��	15,68,0,0q�67   $	��Top=�6J   $	��385��6b   $��2��6n    5      �� 5      $
��232* �6#   �� 5      $
��177* �6#   .+�5      �� -   5         ��Name$ Table��5      $
��Left=�6&   $	��406��6A   $��89,3,-28,-11q�6N   $	��Top=�6d   $	��324��6|    J� RenderTransformOrigin$ 0.474,0.499&�6�   $��2��6�    �� View 5      �� 5      .P�5      �� 	 �� Width$		 100��6Z   
 �� DisplayMemberBinding
 6)   ��  �� Path$ position�.��6f   Позиция6o   �� 5      $		 100��6Z   
 6)   �� $ 
SumRatings�.��6f   Рейтинг6o   �� 5      $		 120��6T   
 6)   �� $
 name�.��6`   !Название команды6r   5      5       5"      5(      5)      