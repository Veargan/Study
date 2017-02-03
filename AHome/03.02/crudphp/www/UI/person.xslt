<?xml version="1.0"?>
<xsl:stylesheet version="1.0"
                   xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                   xmlns:myNS="http://devedge.netscape.com/2002/de">

  <xsl:output method="html" />

  <xsl:template match="Persons">
    <table>
      <xsl:apply-templates />
    </table>
  </xsl:template>

  <xsl:template match="Persons/Person">
    <tr class="tableItem">
      <td class="tableItem">
        <xsl:value-of select="id"/>
      </td>
      <td class="tableItem">
        <xsl:value-of select="firstName"/>
      </td>
	   <td class="tableItem">
        <xsl:value-of select="lastName"/>
      </td>
	   <td class="tableItem">
        <xsl:value-of select="age"/>
      </td>
    </tr>
  </xsl:template>
</xsl:stylesheet>
