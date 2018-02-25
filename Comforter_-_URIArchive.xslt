<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:include href="20050929NorikoYoshida.xslt" />
<xsl:output method="html" indent="no" />
 <xsl:template match="/">
  <html>
   <body>
      <table align="center" border="1">
        <tbody>
          <xsl:apply-templates select="//uri">
             <xsl:sort select="../title" data-type="text" 
                  order="ascending" case-order="lower-first"/>
             <xsl:sort select="current()" data-type="text" 
                  order="ascending" case-order="lower-first"/>
             <xsl:sort select="position()" data-type="number" 
                  order="ascending" case-order="lower-first"/> 
          </xsl:apply-templates>
         </tbody>
      </table>
  </body>
 </html>
 </xsl:template>

 <xsl:template match="//uri">
  <xsl:variable name="norikoYoshidaProtocol">
   <xsl:call-template name="NorikoYoshidaProtocol">
    <xsl:with-param name="uri" select="current()"/>
   </xsl:call-template>
  </xsl:variable>
  <tr align="center">
   <td>
   	<xsl:choose>
     <xsl:when test="../title!=''">
      <a target="_blank" href="{$norikoYoshidaProtocol}">
       <xsl:value-of select="../title"/>
      </a>
     </xsl:when>
     <xsl:otherwise>
      <a target="_blank" href="{$norikoYoshidaProtocol}">
       <xsl:value-of select="current()"/>
      </a>
     </xsl:otherwise>
   	</xsl:choose>
   </td>
  </tr>
 </xsl:template>
</xsl:stylesheet>
