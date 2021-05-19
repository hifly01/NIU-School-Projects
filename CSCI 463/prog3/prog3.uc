0000 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 0001   # do nothing

#############################
# fetch an insn from PC address 
0001 0  0 0 0  0 1 0 0 0  0 0 5  0 4 0 7 0002   # put the PC reg value into the MAR
0002 0  0 0 0  0 0 0 0 1  0 0 5  0 4 0 7 0003   # falling edge on uc_mar_we, rising edge on uc_mbr_in_we
0003 0  0 0 0  0 0 0 0 0  0 0 5  0 4 0 7 0004   # falling edge on uc_mbr_in_we
0004 0  0 0 0  0 0 0 0 0  1 0 5  0 7 0 4 0005   # rising edge on uc_reg_we_clk w/ir as target
0005 0  0 0 0  0 0 0 0 0  0 0 5  0 7 0 4 0006   # falling edge on uc_reg_we_clk

# add 1 to PC
0006 0  0 0 1  0 0 0 0 0  1 0 4  0 4 0 7 0007   # add 1 to PC & rising edge on uc_reg_we_clk
0007 0  0 0 1  0 0 0 0 0  0 0 4  0 4 0 7 0010   # falling edge on uc_reg_we_clk

#############################
# instruction decode logic
0010 2  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 00f0   # branch based on the opcode in the IR!

00f0 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1000   # opcode 0 NOP
00f1 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1100   # opcode 1 LD Ra,imm
00f2 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1200   # opcode 2 ST Ra,imm
00f3 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1300   # opcode 3 ADD Ra,Rb
00f4 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1400   # opcode 4 SUB Ra,Rb
00f5 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1500   # opcode 5 XOR Ra,Rb
00f6 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1600   # opcode 6 AND Ra,Rb
00f7 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1700   # opcode 7 OR Ra,Rb
00f8 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1800   # opcode 8 MOV Ra,Rb
00f9 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1900   # opcode 9 LD Ra,mem(imm)
00fa 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1a00   # opcode a B imm (absolute)
00fb 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1b00   # opcode b BR PC+imm
00fc 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1c00   # opcode c BZ PC+imm
00fd 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1d00   # opcode d BNZ PC+imm
00fe 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 ffff   # opcode e
00ff 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 ffff   # opcode f HALT

#############################
# NOP no operation
1000 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 0001   # go to insn fetch

#############################
# LDI Ra,imm
# fetch the byte in memory that the PC is pointing to now
1100 0  0 0 0  0 1 0 0 0  0 0 7  0 4 0 7 1101   # MAR <- PC
1101 0  0 0 0  0 0 0 0 0  0 0 7  0 4 0 7 1102   #
1102 0  0 0 0  0 0 0 0 1  0 0 7  0 7 0 7 1103   # MBR_IN <- d_in
1103 0  0 0 0  0 0 0 0 0  0 0 7  0 7 0 7 1104   #
1104 0  0 0 0  0 0 0 0 0  1 1 7  0 7 0 4 1105   # Ra <- MBR_IN
1105 0  0 0 0  0 0 0 0 0  0 1 7  0 7 0 4 1106   #
1106 0  0 0 1  0 0 0 0 0  1 0 4  0 4 0 7 1107   # PC <- PC+1
1107 0  0 0 1  0 0 0 0 0  0 0 4  0 4 0 7 1108   # 

1108 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 0001   # go to insn fetch
#############################
#ST Ra,imm
1200 0  0 0 0  0 1 0 0 0  0 0 7  0 4 0 7 1201   # MAR <- PC
1201 0  0 0 0  0 0 0 0 0  0 0 7  0 4 0 7 1202	#
1202 0  0 0 0  0 0 0 0 1  0 0 7  0 7 0 7 1203   # MBR_IN <- d_in
1203 0  0 0 0  0 0 0 0 0  0 0 7  0 7 0 7 1204   #
1204 0  0 0 0  0 1 0 0 0  0 0 7  0 7 0 4 1205	# MAR <- MBR_in
1205 0  0 0 0  0 0 0 0 0  0 0 7  0 7 0 4 1206	# 4 is the mbr_in from alu_b
1206 0  0 0 0  0 0 0 1 0  0 0 7  1 7 0 7 1207	# MBR_out <- Ra
1207 0  0 0 0  0 0 0 0 0  0 0 7  1 7 0 7 1208
1208 0  0 0 0  0 0 1 0 0  0 0 7  1 7 0 7 1209	# mem(MAR)←MBROUT
1209 0  0 0 0  0 0 0 0 0  0 0 7  0 7 0 7 120a
120a 0  0 0 1  0 0 0 0 0  1 0 4  0 4 0 7 120b   # PC <- PC+1
120b 0  0 0 1  0 0 0 0 0  0 0 4  0 4 0 7 120c   #

120c 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 0001

#############################
#ADD
1300 0  0 0 0  1 0 0 0 0  1 1 7  1 7 1 7 1301	# Ra <- Ra + Rb 
1301 0  0 0 0  0 0 0 0 0  0 1 7  1 7 1 7 1302	#

1302 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 0001

#############################
# SUB
1400 0  0 1 1  1 0 0 0 0  1 1 7  1 7 1 7 1401   # Ra <- Ra - Rb
1401 0  0 1 1  0 0 0 0 0  0 1 7  1 7 1 7 1402   #

1402 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 0001

#############################
# XOR
1500 0  1 0 0  1 0 0 0 0  1 1 7  1 7 1 7 1501   # Ra <- Ra XOR Rb
1501 0  1 0 0  0 0 0 0 0  0 1 7  1 7 1 7 1502   #

1502 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 0001

############################
# AND
1600 0  2 0 0  1 0 0 0 0  1 1 7  1 7 1 7 1601   # Ra <- Ra & Rb
1601 0  2 0 0  0 0 0 0 0  0 1 7  1 7 1 7 1602   #

1602 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 0001

############################
# OR
1700 0  3 0 0  1 0 0 0 0  1 1 7  1 7 1 7 1701   # Ra <- Ra || Rb
1701 0  3 0 0  0 0 0 0 0  0 1 7  1 7 1 7 1702   #

1702 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 0001
############################
# MOV
1800 0  0 0 0  0 0 0 0 0  1 1 7  0 7 1 7 1801	# Ra <- Rb
1801 0  0 0 0  0 0 0 0 0  0 1 7  0 7 1 7 1802

1802 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 0001

############################
# LD 
1900 0  0 0 0  0 1 0 0 0  0 0 7  0 4 0 7 1901   # MAR <- PC
1901 0  0 0 0  0 0 0 0 0  0 0 7  0 4 0 7 1902   # from the ldi
1902 0  0 0 0  0 0 0 0 1  0 0 7  0 7 0 7 1903   # MBR_IN <- d_in
1903 0  0 0 0  0 0 0 0 0  0 0 7  0 7 0 7 1904   # from the ldi
1904 0  0 0 0  0 1 0 0 0  0 0 7  0 7 0 4 1905   # MAR <- MBR_in
1905 0  0 0 0  0 0 0 0 0  0 0 7  0 7 0 4 1906   #
1906 0  0 0 0  0 0 0 0 1  0 0 7  0 7 0 7 1907   # MBR_IN <- d_in
1907 0  0 0 0  0 0 0 0 0  0 0 7  0 7 0 7 1908   # from the ldi
1908 0  0 0 0  0 0 0 0 0  1 1 7  0 7 0 4 1909   # Ra <- MBR_IN
1909 0  0 0 0  0 0 0 0 0  0 1 7  0 7 0 4 190a   # from ldi
190a 0  0 0 1  0 0 0 0 0  1 0 4  0 4 0 7 190b   # PC <- PC+1
190b 0  0 0 1  0 0 0 0 0  0 0 4  0 4 0 7 190c   # from ldi

190c 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 0001

############################
# B
1a00 0  0 0 0  0 1 0 0 0  0 0 7  0 4 0 7 1a01   # MAR <- PC
1a01 0  0 0 0  0 0 0 0 0  0 0 7  0 4 0 7 1a02   #
1a02 0  0 0 0  0 0 0 0 1  0 0 7  0 7 0 7 1a03   # MBR_IN <- d_in
1a03 0  0 0 0  0 0 0 0 0  0 0 7  0 7 0 7 1a04   #
1a04 0  0 0 0  0 0 0 0 1  1 0 4  0 7 0 4 1a05	# PC <- MBR_IN
1a05 0  0 0 0  0 0 0 0 0  0 0 4  0 7 0 4 1a06	#

1a06 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 0001

############################
# BR
1b00 0  0 0 0  0 1 0 0 0  0 0 7  0 4 0 7 1b01   # MAR <- PC
1b01 0  0 0 0  0 0 0 0 0  0 0 7  0 4 0 7 1b02   #
1b02 0  0 0 0  0 0 0 0 1  0 0 7  0 7 0 7 1b03   # MBR_IN <- d_in
1b03 0  0 0 0  0 0 0 0 0  0 0 7  0 7 0 7 1b04   #
1b04 0  0 0 1  0 0 0 0 0  1 0 4  0 4 0 7 1b05   # PC <- PC+1
1b05 0  0 0 1  0 0 0 0 0  0 0 4  0 4 0 7 1b06   #
1b06 0  0 0 0  0 0 0 0 0  1 0 4  0 4 0 4 1b07	# PC <- PC + MBR_IN
1b07 0  0 0 0  0 0 0 0 0  0 0 4  0 4 0 4 1b08	#

1b08 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 0001

###########################
# BZ
1c00 1  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1c10	# branch if 0 to 1b00
						# else go to 190a to increase PC +1

1c10 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 190a	#NZ
1c11 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 190a   #NZ
1c12 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1b00   #Z
1c13 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1b00   #Z
1c14 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 190a   #NZ
1c15 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 190a   #NZ
1c16 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1b00   #Z
1c17 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1b00   #Z
1c18 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 190a   #NZ
1c19 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 190a   #NZ
1c1a 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1b00   #Z
1c1b 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1b00   #Z
1c1c 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 190a   #NZ
1c1d 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 190a   #NZ
1c1e 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1b00   #Z
1c1f 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1b00   #Z


###########################
# BNZ
1d00 1  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1d10   # branch to 1b00 if not 0
						# else increase PC +1

1d10 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1b00	#NZ
1d11 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1b00	#NZ
1d12 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 190a	#Z
1d13 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 190a	#Z
1d14 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1b00	#NZ
1d15 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1b00	#NZ
1d16 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 190a	#Z
1d17 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 190a	#Z
1d18 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1b00	#NZ
1d19 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1b00	#NZ
1d1a 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 190a	#Z
1d1b 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 190a	#Z
1d1c 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1b00	#NZ
1d1d 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 1b00	#NZ
1d1e 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 190a	#Z
1d1f 0  0 0 0  0 0 0 0 0  0 0 0  0 7 0 7 190a	#Z
