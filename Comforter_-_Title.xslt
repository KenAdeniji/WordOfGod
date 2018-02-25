<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
<xsl:output method="html" indent="no" />
 <xsl:template match="/">
  <html>
   <body>
    <table align="center" border="1">
     <theader>
      <tr align="center"><td colspan="6">
      Titles of the Triune God
      (
        <a target="_blank" 
href="http://bible.crosswalk.com/OnlineStudyBible/bible.cgi?new=1&amp;word=Matthew+1%3A1%2C+Matthew+12%3A23%2C+Matthew+15%3A22%2C+Matthew+21%3A9%2C+Mark+10%3A48%2C+Mark+12%3A35%2C+John+7%3A42%2C+Romans+1%3A3%2C+2+Timothy+2%3A8%2C+Revelation+5%3A5&amp;section=0&amp;version=nkj&amp;language=en"
        >
        1 John 5:7, Matthew 3:16-17, Mark 1:10-11, Luke 3:22, John 1:32-34, Isaiah 11:2
        </a>
      )
      </td></tr>   
      <tr align="center">
       <td>Title</td>
       <td>Meaning</td>
       <td>Scripture Reference</td>
      </tr>   
     </theader>
     <tbody>
      <xsl:apply-templates select="titles/title">
       <xsl:sort select="@nameSequence" data-type="number" order="ascending" case-order="lower-first"/>
       <xsl:sort select="@title" data-type="text" order="ascending" case-order="lower-first"/> 
      </xsl:apply-templates>
     </tbody>
    </table>		
  </body>
 </html>
 </xsl:template>

 <xsl:template match="titles/title">
   <tr align="center">
    <td>
      <xsl:if test="@scriptureReferenceURI=''"><xsl:value-of select="@title"/></xsl:if>
      <xsl:if test="@scriptureReferenceURI!='' "><a target="_blank" href="{@scriptureReferenceURI}"><xsl:value-of select="@title"/></a></xsl:if>
    </td> 
    <td>
      <xsl:if test="@scriptureReferenceURI=''"><xsl:value-of select="@meaning"/></xsl:if>
      <xsl:if test="@scriptureReferenceURI!='' "><a target="_blank" href="{@scriptureReferenceURI}"><xsl:value-of select="@meaning"/></a></xsl:if>
    </td> 
    <td>
      <xsl:if test="@scriptureReferenceURI=''"><xsl:value-of select="@scriptureReference"/></xsl:if>
      <xsl:if test="@scriptureReferenceURI!='' "><a target="_blank" href="{@scriptureReferenceURI}"><xsl:value-of select="@scriptureReference"/></a></xsl:if>
    </td> 
  </tr>
 </xsl:template>

</xsl:stylesheet>

<!--
Legal filter operators are:
 =    (equal) 
 !=   (not equal) 
 &lt; less than 
 &gt; greater than
-->

<!-- 
HTML Special Entities
ampersand     &        &amp;
-->